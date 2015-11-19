angular.module('MovieApp', []);
angular.module('MovieApp')
    .controller('MovieListController', function () {
    this.movies = ['Pulp Fiction', 'Memento', 'New Jack City'];
    this.addNewMovie = function (newMovie) {
        if (newMovie) {
            this.movies.push(newMovie);
        }
    };
});
