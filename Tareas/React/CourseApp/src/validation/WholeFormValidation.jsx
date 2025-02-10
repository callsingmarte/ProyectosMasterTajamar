
export function ValidateForm(data) {
    let errors = []

    if (data.seatCapacity < 0) {
        errors.push("Seat capacity cannot be negative")
    }

    return errors
}