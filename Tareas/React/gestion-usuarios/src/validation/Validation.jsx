import validator from "validator"
export function ValidateData(data, rules) {
    let errors = {}
    Object.keys(data).forEach(field => {
        if (rules.hasOwnProperty(field)) {
            let fielderrors = []
            let val = data[field]

            if (rules[field].required && validator.isEmpty(val)) {
                fielderrors.push("Value required")
            }
            if (rules[field].email && !validator.isEmail(val)) {
                fielderrors.push("Enter a valid email address")
            }

            if (fielderrors.length > 0) {
                errors[field] = fielderrors
            }
        }
    })

    return errors
}