/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
  System.config({
    paths: {
      // paths serve as alias
      'npm:': 'node_modules/'
    },
    // map tells the System loader where to look for things
    map: {
      // our app is within the app folder
      app: 'app',
      // angular bundles
      '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
      '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
      '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
      '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
      '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
      '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
      '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
      '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
      // other libraries
      'rxjs':                       'npm:rxjs',
      '@ngrx/core':                 'npm:@ngrx/core/bundles/core.umd.js',
      '@ngrx/store':                'npm:@ngrx/store/bundles/store.umd.js',
      'angular-in-memory-web-api':  'npm:angular-in-memory-web-api',      
      'ng2-file-upload':            'node_modules/ng2-file-upload',
      // application barrels      
      'shared':                     'app/shared',
      'core':                       'app/core',
      'user-account':               'app/user-account',
      'email-accounts':             'app/email-accounts',
      'home':                       'app/home',
      'accounts':                   'app/accounts',
      'authorize':                  'app/authorize'
    },
    // packages tells the System loader how to load when no filename and/or no extension
    packages: {
      app:                                              { main: './main.js', defaultExtension: 'js' },
      rxjs:                                             { defaultExtension: 'js' },
      'angular-in-memory-web-api':                      { main: './index.js', defaultExtension: 'js' },
      'ng2-file-upload':                                { defaultExtension:'js' },      
      'shared':                                         { main: 'index.js', defaultExtension: 'js' },
      'shared/services':                                { main: 'index.js', defaultExtension: 'js' },
      'shared/reducers':                                { main: 'index.js', defaultExtension: 'js' },
      'shared/models':                                  { main: 'index.js', defaultExtension: 'js' },
      'core':                                           { main: 'index.js', defaultExtension: 'js' },
      'user-account':                                   { main: 'index.js', defaultExtension: 'js' },
      'user-account/shared':                            { main: 'index.js', defaultExtension: 'js' },
      'user-account/user-account-registration':         { main: 'index.js', defaultExtension: 'js' },
      'email-accounts':                                 { main: 'index.js', defaultExtension: 'js' },
      'email-accounts/imap-settings-form':              { main: 'index.js', defaultExtension: 'js' },
      'email-accounts/shared':                          { main: 'index.js', defaultExtension: 'js' },
      'email-accounts/email-account-card':              { main: 'index.js', defaultExtension: 'js' },
      'email-accounts/email-account-list':              { main: 'index.js', defaultExtension: 'js' },
      'core/nav':                                       { main: 'index.js', defaultExtension: 'js' },
      'home':                                           { main: 'index.js', defaultExtension: 'js' },
      'accounts':                                       { main: 'index.js', defaultExtension: 'js' },
      'accounts/shared':                                { main: 'index.js', defaultExtension: 'js' },
      'accounts/transaction-table':                     { main: 'index.js', defaultExtension: 'js' },
      'authorize':                                      { main: 'index.js', defaultExtension: 'js' }
    }
  });
})(this);