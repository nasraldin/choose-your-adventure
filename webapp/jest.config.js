const { pathsToModuleNameMapper } = require('ts-jest/utils');
const { defaults } = require('jest-config');
const { compilerOptions } = require('./tsconfig');

module.exports = {
  verbose: true,
  preset: 'jest-preset-angular',
  snapshotSerializers: [
    'jest-preset-angular/build/AngularNoNgAttributesSnapshotSerializer.js',
    'jest-preset-angular/build/AngularSnapshotSerializer.js',
    'jest-preset-angular/build/HTMLCommentSerializer.js'
  ],
  roots: ['<rootDir>/src/'],
  testMatch: ['**/+(*.)+(spec).+(ts)'],
  setupFilesAfterEnv: [
    '<rootDir>/setupJest.ts',
  ],
  moduleFileExtensions: [
    ...defaults.moduleFileExtensions,
    'js', 'json', 'jsx', 'ts', 'tsx', 'node'
  ],
  modulePaths: ['<rootDir>/src/'],
  moduleNameMapper: pathsToModuleNameMapper(
    compilerOptions.paths || {}, {
    prefix: '<rootDir>/src/'
  }),
  notify: false,
  notifyMode: 'failure-change',
  resetModules: true,
  transform: {
    '^.+\\.(ts|js|html)$': 'ts-jest',
    '^.+\\.js$': 'babel-jest'
  },
  coveragePathIgnorePatterns: [
    "/node_modules/",
    "/jest/"
  ],
  collectCoverage: true,
  coverageReporters: ['text-summary', 'json', 'lcov', 'text', 'clover'],
  coverageDirectory: 'coverage/app',
  coverageThreshold: {
    global: {
      branches: 50,
      functions: 50,
      lines: 50,
      statements: 50
    }
  },
};
