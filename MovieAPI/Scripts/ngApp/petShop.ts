class Pet {
    type: string;
    breed: string;
    name: string;
    weight: number;
    size: string;
    gender: string;
    age: number;
    Image: string;

    constructor(type: string, breed: string, name: string, weight: number, size: string, gender: string, age: number, Image: string) {
    }

}

class Dog extends Pet {
    constructor(breed: string, name: string, weight: number, size: string, gender: string, age: number, Image: string) {
        super('Dog', breed, name, weight, size, gender, age, Image);
    }
}

class Rabbit extends Pet {
    constructor(breed: string, name: string, weight: number, size: string, gender: string, age: number, Image: string) {
        super('Rabbit', breed, name, weight, 'Small', gender, age, Image);
    }
}
angular.module('MovieApp')
    .controller('PetShopController', function () {

        this.pets = {
            dogs: [
                new Dog('Black Lab', 'Havoc', 55, 'Medium', 'Male', 1, 'https://xxxxx.jpg'),
                new Dog('Husky', 'Bart', 80, 'Large', 'Female', 12, 'http://xxxx.jpg'),
                new Dog('Corgi', 'Jim', 49, 'Small', 'Male', 2, 'http://xxxx.jpg')
            ],
            bunnies: [
                new Rabbit('Belgian Ware', 'Peter', 10, 'Medium', 'Male' , 2, 'http://xxx.jpg')
            ]
        };
    });