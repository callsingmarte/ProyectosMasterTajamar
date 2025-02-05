import { useState } from "react";

export function HooksButton(props) {
    const [counter, setCounter] = useState(0)
    const [hasButtonClicked, setHasButtonClicked] = useState(false)

    const handleClick = () => {
        setCounter(counter + 5);
        setHasButtonClicked(true)
        props.callback();
    }

    return (
        <button onClick={handleClick} className={props.className}
            disabled={ props.disabled === "true" || props.disabled === true}
        >{props.text}{counter}{hasButtonClicked && <div>Button clicked!</div>}
        </button>
    )
}