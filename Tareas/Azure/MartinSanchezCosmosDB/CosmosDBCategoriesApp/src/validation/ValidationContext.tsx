import * as React from "react";

export const ValidationContext = React.createContext({
    getMessagesForField: (field?: string) => []
})