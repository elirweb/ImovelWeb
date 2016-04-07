(function () {
    'use strict';
    angular.module('empreendimentoApp', [ 'servicemodule'
        ]);
})();


(function () {
    'use strict';
    angular
    .module('empreendimentoApp')
    .controller('ctrlempreendimento', ctrlempreendimento);
    ctrlempreendimento.$inject = ['$scope', 'Movies'];

    function ctrlempreendimento($scope, Movies) {
        $scope.movies = Movies.query();
    }
});

(function () {
    'use strict';
    var servicemodule = angular.module('servicemodule', ['ngResource']);
    servicemodule.factory('Movies', ['$resource',
        function ($resource) {
            return $resource('http://localhost:50642/empreendimento/todos', {}, {
                query: { method: 'GET', params: {}, isArray:true}
            });
        }]);
    
})();