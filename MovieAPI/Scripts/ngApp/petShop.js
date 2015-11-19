var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Pet = (function () {
    function Pet(type, breed, name, weight, size, gender, age, Image) {
    }
    return Pet;
})();
var Dog = (function (_super) {
    __extends(Dog, _super);
    function Dog(breed, name, weight, size, gender, age, Image) {
        _super.call(this, 'Dog', breed, name, weight, size, gender, age, Image);
    }
    return Dog;
})(Pet);
var Rabbit = (function (_super) {
    __extends(Rabbit, _super);
    function Rabbit(breed, name, weight, size, gender, age, Image) {
        _super.call(this, 'Rabbit', breed, name, weight, 'Small', gender, age, Image);
    }
    return Rabbit;
})(Pet);
angular.module('MovieApp')
    .controller('PetShopController', function () {
    this.pets = {
        dogs: [
            new Dog('Black Lab', 'Havoc', 55, 'Medium', 'Male', 1, 'https://xxxxx.jpg'),
            new Dog('Husky', 'Bart', 80, 'Large', 'Female', 12, 'http://xxxx.jpg'),
            new Dog('Corgi', 'Jim', 49, 'Small', 'Male', 2, 'http://xxxx.jpg')
        ],
        bunnies: [
            new Rabbit('Belgian Ware', 'Peter', 10, 'Medium', 'Male', 2, 'http://xxx.jpg')
        ]
    };
});
