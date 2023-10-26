import Counter from './Components/Counter'
import './App.css'
import Heading from './Components/Heading'

function App() {
  

  return (
    <div>


      <Heading headingName="This is the name that is passed via props" />
      <Counter/>
    </div>
  )
}

export default App
