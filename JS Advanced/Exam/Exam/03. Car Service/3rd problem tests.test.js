let {assert} = require('chai');

let {chooseYourCar} = require('./chooseYourCar');


describe("test Choose your car obj …", function() {

    describe(" test choosingType (type, color, year)", function() {

        it("test the year is between 1900 and 2022", function() {

            assert.throws( function() {chooseYourCar.choosingType("Sedan", "Red", 1800);},Error,"Invalid Year!" );
            assert.throws( function() {chooseYourCar.choosingType("Sedan", "Red", 2500);},Error,"Invalid Year!" );

        });
        it("test the type is Sedan", function() {

            assert.throws( function() {chooseYourCar.choosingType("4W4", "Red", 1999);},Error,"This type of car is not what you are looking for." );
            //assert.throws( function() {chooseYourCar.choosingType("Sedan", "Red", 2500);},Error,"Invalid Year!" );

        });
        it("test if the car is picked", function() {

            assert.equal(chooseYourCar.choosingType("Sedan", "Red", 2010),`This Red Sedan meets the requirements, that you have.`);

        });
        it("test if the car is too old", function() {

            assert.equal(chooseYourCar.choosingType("Sedan", "Red", 2009),"This Sedan is too old for you, especially with that Red color.");

        });

     });
     
     describe(" test brandName (brands, brandIndex)", function() {

        it("test if the array removes a brand correctly", function() {

            assert.equal(chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"],2), "BMW, Toyota")

        });

        it("test if the input is correct", function() {
            let arr = [];
            let index = "";

            assert.throws( function() {chooseYourCar.brandName(arr, index);},Error,"Invalid Information!" );


        });
        it("test if the input is correct", function() {
            let arr = {};
            let index = "";

            assert.throws( function() {chooseYourCar.brandName(arr, index);},Error,"Invalid Information!" );


        });
        it("test if the input is correct", function() {
            let arr = {};
            let index = 9;

            assert.throws( function() {chooseYourCar.brandName(arr, index);},Error,"Invalid Information!" );


        });
        it("test if the input is correct", function() {
            let arr = "fghj";
            let index = {};

            assert.throws( function() {chooseYourCar.brandName(arr, index);},Error,"Invalid Information!" );


        });
        it("test if the input is correct", function() {
            let arr = [];
            let index = [];

            assert.throws( function() {chooseYourCar.brandName(arr, index);},Error,"Invalid Information!" );


        });
        it("test if the input is correct", function() {
            let arr = ["BMW", "Toyota", "Peugeot"];
            let index = -2;

            assert.throws( function() {chooseYourCar.brandName(arr, index);},Error,"Invalid Information!" );


        });
        it("test if the input is correct", function() {
            let arr = ["BMW", "Toyota", "Peugeot"];
            let index = 50;

            assert.throws( function() {chooseYourCar.brandName(arr, index);},Error,"Invalid Information!" );


        });
       

     });


     describe(" test CarFuelConsumption (distanceInKilometers, consumptedFuelInLitres)", function() {

        it("if consumption is more than 7", function() {
            let distance = 100;
            let consumption = 10;

            assert.equal(chooseYourCar.carFuelConsumption(distance, consumption), "The car burns too much fuel - 10.00 liters!");

        });
        it("if consumption is 7 or less", function() {
            let distance = 100;
            let consumption = 7;

            assert.equal(chooseYourCar.carFuelConsumption(distance, consumption), "The car is efficient enough, it burns 7.00 liters/100 km.");

        });
        it("if consumption is 7 or less", function() {
            let distance = 100;
            let consumption = 6;

            assert.equal(chooseYourCar.carFuelConsumption(distance, consumption), "The car is efficient enough, it burns 6.00 liters/100 km.");

        });
        it("if input is valid", function() {
            let distance = -100;
            let consumption = 6;

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = -100;
            let consumption = -6;

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = 100;
            let consumption = -6;

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = [];
            let consumption = [];

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = [];
            let consumption = [];

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = {};
            let consumption = [];

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = "";
            let consumption = [];

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = 5;
            let consumption = {};

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });
        it("if input is valid", function() {
            let distance = 6;
            let consumption = "";

            assert.throws( function() {chooseYourCar.carFuelConsumption(distance, consumption);},Error,"Invalid Information!" );

        });

       
       



     });
});