import React from 'react'

import image from '../../Assets/Images/premium-accessories-collection-flatlay.jpg'

const HeroSection = () => {
    return (
        <>
            <div className=''>
                <section className="px-4 sm:px-6 lg:px-8 py-12 md:py-24">
                    <div className="max-w-7xl mx-auto">
                        <div className="grid grid-cols-1 md:grid-cols-2 gap-8 items-center">
                            {/* Content */}
                            <div className="space-y-6">
                                <h1 className="text-4xl md:text-5xl font-bold text-foreground text-balance leading-tight">
                                    Discover your next favorite piece
                                </h1>
                                <p className="text-lg text-muted-foreground leading-relaxed">
                                    Curated collections of premium lifestyle products designed to elevate your everyday moments.
                                </p>
                                <div className="flex gap-3">
                                    <button className="px-8 py-3 bg-blue-600 text-(--primary-foreground) rounded-full font-medium  transition hover:bg-blue-700/90">
                                        Shop Now
                                    </button>
                                    <button className="px-8 py-3 bg-(--secondary) text-(--secondary-foreground) rounded-full font-medium hover:bg-(--secondary)
                                     transition border border-(--border)">
                                        Explore Collections
                                    </button>
                                </div>
                            </div>

                            <div className="h-64 md:h-96 bg-linear-to-br from-accent/20 via-primary/10 to-accent/20 rounded-2xl flex items-center justify-center">
                                <img
                                    src={image}
                                    alt="Featured lifestyle product"
                                    className="w-full h-full object-cover rounded-2xl"
                                />
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </>
    )
}

export default HeroSection