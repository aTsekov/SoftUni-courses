class Rectangle{
    constructor(width, height, color){
        this.width = width;
        this.height = height;
        this.color = color;
    }

    calcArea(){
        return this.width * this.height;
    }
}

let firstRectangle = new Rectangle(4,5,"Red")
console.log(firstRectangle.calcArea());