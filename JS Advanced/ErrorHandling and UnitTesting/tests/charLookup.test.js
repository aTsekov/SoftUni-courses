const { expect } = require('chai');
let assert = require('chai');
let { lookupChar } = require("../03. Char Lookup");

describe("Test char lookup functionalities", () => {

    it("If first param is not a string return undefined", () => {
        // arrange
        let param1 = 9;
        let param2 = 9;
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })

    it("If first param is not a string return undefined", () => {
        // arrange
        let param1 = [];
        let param2 = 7.7;
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        if (typeof (param1) !== 'string' || !Number.isInteger(param2)) {
            return undefined;
        }

    })
    it("If first param is not a string return undefined", () => {
        // arrange
        let param1 = true;
        let param2 = 9;
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If first param is not a string return undefined", () => {
        // arrange
        let param1 = {};
        let param2 = 9;
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If second param is not a num return undefined", () => {
        // arrange
        let param1 = "test";
        let param2 = "test2";
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If second param is not a num return undefined", () => {
        // arrange
        let param1 = "test";
        let param2 = 9.9;
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If second param is not a num return undefined", () => {
        // arrange
        let param1 = "test";
        let param2 = [];
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If second param is not a num return undefined", () => {
        // arrange
        let param1 = "test";
        let param2 = {};
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If second param is not a num return undefined", () => {
        // arrange
        let param1 = "test";
        let param2 = true;
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If both params are the wrong type return undefined", () => {
        // arrange
        let param1 = 9;
        let param2 = "test2";
        // Act 
        let res = lookupChar(param1, param2);
        // Assert
        expect(res).to.be.undefined;

    })
    it("If both params are the correct type but the index is negative return Incorrect index", () => {
        let string = "Antoni";
        let index = -1;
        if (string.length <= index || index < 0) {
            return "Incorrect index";
        }



    })

    it("If both params are the correct type but the index is negative return Incorrect index", () => {
        let string = "Antoni";
        let index = 10;
        expect(lookupChar(string, index)).to.equal("Incorrect index");

    })
    it("If both params are the correct type but the index is negative return Incorrect index", () => {

        let string = "Antoni";
        let index = -1;
        expect(lookupChar(string, index)).to.equal("Incorrect index");

    })
    it("If both params are the correct type but the index is bigger than the string's length return Incorrect index", () => {

        let string = "Antoni";
        let index = 7;
        expect(lookupChar(string, index)).to.equal("Incorrect index");

    })
    it("If both parameters have correct types and values - return the character at the specified index in the string.", () => {
        lookupChar("Antoni", 6)
        let string = "Antoni";
        let index = 5;
        expect(lookupChar(string, index)).to.equal("i");

    })

});

