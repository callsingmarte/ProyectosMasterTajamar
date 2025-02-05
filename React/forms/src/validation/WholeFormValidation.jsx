export function ValidateForm(data) {
    let errors = []

    if (!data.email.endsWith("@example.com")) {
        errors.push("Only example.com users allowed")
    }
    if (!data.email.toLowerCase().startsWith(data.name.toLowerCase())) {
        errors.push("Email address must start with the name")
    }
    if (data.name.toLowerCase() === "Javier") {
        errors.push("A parla")
    }

    return errors
}