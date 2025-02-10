import validator from "validator"
export function ValidateData(data, rules) {
    let errors = {}
    Object.keys(data).forEach(field => {
        if (rules.hasOwnProperty(field)) {
            let fielderrors = []
            let val = data[field]
            if (typeof val == "string") {
                if (rules[field].required && validator.isEmpty(val)) {
                    fielderrors.push("Value required")
                }
                if (!validator.isEmpty(data[field])) {
                    if (rules[field].alpha && !validator.isAlpha(val)) {
                        fielderrors.push("Enter only letters")
                    }
                    if (rules[field].numeric && !validator.isNumeric(val)) {
                        fielderrors.push("Enter only numbers")
                    }
                }
            }

            if (fielderrors.length > 0) {
                errors[field] = fielderrors
            }
        }
    })
    return errors
}