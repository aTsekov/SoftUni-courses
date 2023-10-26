import {useState} from "react"; // this is a hook and keeps the state of the component. 

// eslint-disable-next-line no-unused-vars
export default function Counter(props){
    const [count, setCount] = useState(0); // useState is React Hook that allows you to add state to a functional component. The 0 is only the initial state
    //of the value. after the first click it's ignored. 
    //It returns an array with two values: the current state and a function to update it.
    const incrementClickHandler = () => { //This is the event handler when the "+" button is pressed and we attach it to the + button.
        setCount(count + 1);
    };

    const clearCounterHandler = (event) => {
        console.log(event);
        setCount(0);
    }

    let message = null; //This is just a message to display denepnding on the counter value. 

    switch (count) {
        case 1:
            message = 'First blood';
            break;
        case 2:
            message = 'Double kill';
            break;
        case 3:
            message = 'Tripple kill';
            break;
        case 4:
            message = 'Multi kill';
            break;
        case 5:
            message = 'Unstoppable';
            break;
        case 6:
            message = 'God like';
            break;
        default:
            message = 'De nada';
    }

    return(

        <div>
            <h3>Counter</h3>
            {count < 0 ? <p>Invalid count!</p>
            :<p>Valid count!</p>
            }

            <h4>{message}</h4>

            <p>{count}</p>
            <button disabled={count < 0} onClick={() => setCount(count - 1)}>-</button>
            <button onClick={clearCounterHandler}>clear</button>
            <button onClick={incrementClickHandler}>+</button>
        </div>

        

    );
}