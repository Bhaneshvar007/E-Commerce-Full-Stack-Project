export const PasswordValidatore = (password) => {
    const regex =
        /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;

    if (!password) {
        return "Password is required";
    }

    if (!regex.test(password)) {
        return "Password must be at least 8 characters and include uppercase, lowercase, number & special character";
    }

    return null;
};



export const EmailValidatore = (email) => {
    const regex =
        /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!email) {
        return "Email is required";
    }

    if (!regex.test(email)) {
        return "Invalid email address";
    }

    return null;
};

