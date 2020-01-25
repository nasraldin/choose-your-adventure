/**
 * Jest initial setup actions
 *
 * It also enables the following to all Jest tests
 *  . window.localStorage
 *  . window.sessionStorage
 *  . MockPipe()
 *  . MockComponent()
 *  . MockDirective()
 */

// common rxjs imports
import 'rxjs';
import {
  Component,
  Directive,
  EventEmitter,
  Pipe,
  PipeTransform,
  Type
} from '@angular/core';

Error.stackTraceLimit = 2;

const mock = () => {
  let storage = {};

  return {
    getItem: key => (key in storage ? storage[key] : undefined),
    setItem: (key, value) => (storage[key] = value || ''),
    removeItem: key => delete storage[key],
    clear: () => (storage = {})
  };
};

Object.defineProperty(window, 'localStorage', { value: mock() });
Object.defineProperty(window, 'sessionStorage', { value: mock() });

/**
 * Examples:
 * MockPipe('some-pipe');
 * MockPipe('some-pipe', () => 'foo');
 */
export function MockPipe(name: string, transform?: any): Pipe {
  class Mock implements PipeTransform {
    transform = transform || (() => undefined);
  }

  return Pipe({ name })(Mock as any);
}

/**
 * Examples:
 * MockComponent({selector: 'some-component'});
 * MockComponent({selector: 'some-component', inputs: ['some-input', 'some-other-input']});
 */
export function MockComponent(
  selector: string,
  options: Component = {}
): Component {
  const metadata: Component = {
    selector,
    template: options.template || '',
    inputs: options.inputs || [],
    outputs: options.outputs || [],
    exportAs: options.exportAs || ''
  };

  class Mock {
    constructor() {
      metadata.outputs.forEach(method => {
        this[method] = new EventEmitter<any>();
      });
    }
  }

  return Component(metadata)(Mock as any);
}

/**
 * Examples:
 * MockDirective({selector: '[some-directive]'});
 * MockDirective({selector: '[some-directive]', inputs: ['some-input', 'some-other-input']});
 */
export function MockDirective(
  selector: string,
  options: Directive = {}
): Directive {
  const metadata: Directive = {
    selector,
    inputs: options.inputs || [],
    outputs: options.outputs || [],
    providers: options.providers || [],
    exportAs: options.exportAs || ''
  };

  class Mock {
    constructor() {
      metadata.outputs.forEach(method => {
        this[method] = new EventEmitter<any>();
      });
    }
  }

  return Directive(metadata)(Mock as any);
}
