export default function Heading (props){
    // eslint-disable-next-line react/prop-types
    return(<h2 className="site-header">{props.headingName}</h2>) // Provide the props in the Apps.jsx. 
    //This can be a name or a list with many objects inside. 
}