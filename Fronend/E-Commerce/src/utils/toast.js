import { toast } from "react-hot-toast";

export const showSuccess = (message) => {
  toast.success(message, {
    duration: 5000,
    position: "top-right",
  });
};

export const showError = (message) => {
  toast.error(message, {
    duration: 5000,
    position: "top-right",
  });
};
