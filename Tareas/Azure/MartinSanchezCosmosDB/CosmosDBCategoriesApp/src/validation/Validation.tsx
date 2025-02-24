import validator from "validator"
export function ValidateData(data: any, rules: any) {
    let errors: any = {}
    Object.keys(data).forEach(field => {
        if (rules.hasOwnProperty(field)) {
            let fielderrors = []
            let val = data[field]

            if (rules[field].required && validator.isEmpty(val)) {
                fielderrors.push("Value required")
            }

            if (fielderrors.length > 0) {
                errors[field] = fielderrors
            }
        }
    })

    return errors
}