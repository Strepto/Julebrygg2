angular.module('app.routes', ['ionicUIRouter'])

.config(function($stateProvider, $urlRouterProvider) {

  // Ionic uses AngularUI Router which uses the concept of states
  // Learn more here: https://github.com/angular-ui/ui-router
  // Set up the various states which the app can be in.
  // Each state's controller can be found in controllers.js
  $stateProvider
    
  

      .state('tabsController.vurder', {
    url: '/page2',
    views: {
      'tab1': {
        templateUrl: 'templates/vurder.html',
        controller: 'vurderCtrl'
      }
    }
  })

  /* 
    The IonicUIRouter.js UI-Router Modification is being used for this route.
    To navigate to this route, do NOT use a URL. Instead use one of the following:
      1) Using the ui-sref HTML attribute:
        ui-sref='tabsController.logg'
      2) Using $state.go programatically:
        $state.go('tabsController.logg');
    This allows your app to figure out which Tab to open this page in on the fly.
    If you're setting a Tabs default page or modifying the .otherwise for your app and
    must use a URL, use one of the following:
      /page1/tab1/page2
      /page1/tab2/page2
  */
  .state('tabsController.logg', {
    url: '/page2',
    views: {
      'tab1': {
        templateUrl: 'templates/logg.html',
        controller: 'loggCtrl'
      },
      'tab2': {
        templateUrl: 'templates/logg.html',
        controller: 'loggCtrl'
      }
    }
  })

  .state('stats', {
    url: '/page3',
    templateUrl: 'templates/stats.html',
    controller: 'statsCtrl'
  })

  .state('tabsController', {
    url: '/page1',
    templateUrl: 'templates/tabsController.html',
    abstract:true
  })

$urlRouterProvider.otherwise('/page1/page2')

  

});