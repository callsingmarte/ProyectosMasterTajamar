
import React from "react";
function CreateInnerElements(names) {
    //let arrayElements = []
    //for (let i = 0; i < names.length; i++) {
    //    arrayElements.push(
    //        <div>
    //            {`${names[i]} contains ${names[i].length } letters`}
    //        </div>
    //    )
    //}

    //return arrayElements

    return names.map(name =>
        <div>{`${name} contains ${name.length} letters`}</div>
    )

    //    return <h4 className="bg-info text-white text-center p-2">
    //    This is a Summary
    //    </h4>
}

export function Summary(props) {
    //    return <h4 className="bg-info text-white text-center p-2">
    //        { CreateInnerElements(props.names) }
    //    </h4>
    return (
        <h4 className="bg-info text-white text-center p-2">
            {props.names.map(name => 
                <div key= {name}>
                    {`${name} contains ${name.length} letters`}
                </div>            
            )}
        </h4>
    )
}