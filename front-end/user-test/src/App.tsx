import React from 'react';
import SignIn from './pages/SignIn';
import HomePage from './pages/HomePage';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import TestPage from './pages/TestPage';

function App() {
  return (
    <BrowserRouter>
            <Routes>
              <Route path="/" element={<HomePage/>} />
              <Route path="/sign-in" element={<SignIn/>} />
              <Route path="/test/:id" element={<TestPage/>} />
              <Route path="*" element={<h1 style={{ color: 'red' }} >Not Found</h1>} />
            </Routes>
          </BrowserRouter>
  );
}

export default App;
