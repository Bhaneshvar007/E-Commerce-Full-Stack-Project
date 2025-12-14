import React, { useState } from "react";

const Loader = () => {
    const [isLoading, setIsLoading] = useState(false);

    const handleLoad = () => {
        setIsLoading(true);
        // Simulate API call / async
        setTimeout(() => setIsLoading(false), 3000);
    };

    return (
        <div className="w-full h-full fixed top-0 left-0 bg-white opacity-80 z-50 flex items-center justify-center">
            <div className="flex flex-col items-center justify-center">
                <div className="w-24 h-24 border-4 border-transparent border-t-blue-500 rounded-full animate-spin flex items-center justify-center">
                    <div className="w-16 h-16 border-4 border-transparent border-t-red-500 rounded-full animate-spin "></div>
                </div>
            </div>
        </div>
    );
};

export default Loader;


