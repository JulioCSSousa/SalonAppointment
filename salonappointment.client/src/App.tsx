import React from 'react';
import Navbar from './Components/NavBar';
import HeroSection from './Components/HeroSection';
import ServicesSection from './Components/ServiceSection';
import Footer from './Components/Footer';
import Appointment from './Components/Appointment';


const App: React.FC = () => {
  return (
    <div>
      <Navbar />
      <HeroSection />
      <ServicesSection />
      <Appointment />
      <Footer />
    </div>
  );
};

export default App;
