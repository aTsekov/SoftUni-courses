let { assert } = require("chai"); // use chai
let { isOddOrEven } = require("../02.EvenOrOdd"); // import the function. 


describe("Testing Is odd or even function", () => {

    it("Results should be undefined with array", () => {

        assert.equal(isOddOrEven([]), undefined);

    })
    it ("Results should be undefined with number", () => {
        assert.equal(isOddOrEven(9), undefined);
    })
    it ("Results should be undefined with decimal number", () => {
        assert.equal(isOddOrEven(9.9), undefined);
    })
    it ("Results should be undefined with object", () => {
        assert.equal(isOddOrEven({name: "pesho"}), undefined);
    })
    it ("Results should be undefined with boolean", () => {
        assert.equal(isOddOrEven(true), undefined);
    })
    it ("Results should be even", () => {
        assert.equal(isOddOrEven("Mari"), "even");
    })
    it ("Results should be odd", () => {
        assert.equal(isOddOrEven("Maria"), "odd");
    })
})