let {assert} = require('chai');
let {expect} = require('chai');
let {carService} = require('./03. Car Service_Resources');

describe("carService object tests …", function() {
    describe("isItExpensive method tests …", function() {

        it("test if Engine and Transmission or other parts issues return the correct message ", function() {
            let issue = "Engine";
            assert.equal(carService.isItExpensive(issue), `The issue with the car is more severe and it will cost more money`);
            issue = "Transmission";
            assert.equal(carService.isItExpensive(issue), `The issue with the car is more severe and it will cost more money`);
            issue = "another broken part";
            assert.equal(carService.isItExpensive(issue), `The overall price will be a bit cheaper`);
        });
     });

     describe("discount (numberOfParts, totalPrice) method tests …", function() {

        it("assert 15% discount is applied …", function() {
            let res = 15;
            let numOfParts = 3;
            let totalPrice = 100
            assert.equal(carService.discount(numOfParts, totalPrice), `Discount applied! You saved ${res}$`);
        });
        it("assert 30% discount is applied …", function() {
            let res = 30;
            let numOfParts = 8;
            let totalPrice = 100
            assert.equal(carService.discount(numOfParts, totalPrice), `Discount applied! You saved ${res}$`);
        });
        it("assert no discount is applied …", function() {
            
            let numOfParts = 1;
            let totalPrice = 100
            assert.equal(carService.discount(numOfParts, totalPrice), `You cannot apply a discount`);
        });
        it("assert error is thrown if the input is not a number …", function() {
            
            let numOfParts = [];
            let totalPrice = [];
            
            assert.throws( function() {carService.discount(numOfParts, totalPrice);},Error,"Invalid input" );
        });

     });

     
  describe("partsToBuy (partsCatalog, neededParts) method tests …", function() {

    it("TODO …", function() {
        let arr1 = [{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }];
        let arr2 = ["blowoff valve", "injectors"];
        assert.equal(carService.partsToBuy(arr1, arr2), 145);
    });
    it("TODO …", function() {
        let arr1 = [];
        let arr2 = ["blowoff valve", "injectors"];
        assert.equal(carService.partsToBuy(arr1, arr2), 0);
    });

    it("assert error is thrown if the input is not a number …", function() {
        
        let numOfParts = 7;
        let totalPrice = [];
        
        assert.throws( function() {carService.partsToBuy(numOfParts, totalPrice);},Error,"Invalid input" );
    });
    it("assert error is thrown if the input is not a number …", function() {
        
        let numOfParts = {};
        let totalPrice = {};
        
        assert.throws( function() {carService.partsToBuy(numOfParts, totalPrice);},Error,"Invalid input" );
    });
    it("assert error is thrown if the input is not a number …", function() {
        
        let numOfParts = "test";
        let totalPrice = "test";
        
        assert.throws( function() {carService.partsToBuy(numOfParts, totalPrice);},Error,"Invalid input" );
    });
    it("assert error is thrown if the input is not a number …", function() {
        
        let numOfParts = "test";
        let totalPrice = [];
        
        assert.throws( function() {carService.partsToBuy(numOfParts, totalPrice);},Error,"Invalid input" );
    });
 });



     
});