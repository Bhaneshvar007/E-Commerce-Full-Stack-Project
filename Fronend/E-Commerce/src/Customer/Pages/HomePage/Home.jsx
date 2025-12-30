import React from 'react'
import Navbar from '../../Components/Navbar'
import HeroSection from './HeroSection'
import TrustBar from './TrustBar'
 
const Home = () => {
    return (
        <div className=''  style={{ backgroundColor: "oklch(0.98 0.01 70)" }}>
            <Navbar />
            <HeroSection />
            <TrustBar/>
        </div>
    )
}

export default Home