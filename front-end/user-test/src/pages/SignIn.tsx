import React, { useState } from "react";
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import { Button } from "@mui/material";
import Users from "../api/UserAPI";
import { useNavigate } from "react-router-dom";
import Header from "../components/Header/Header";

const SignIn = () => {
    const navigate = useNavigate();
    const [email, setEmail] = useState('');

    const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
    };

    const handleSignIn = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();

        try {
            const user = await Users.SignIn(email);
            console.log(user);
            localStorage.setItem('userId', user.id);
            navigate('/');
        } catch (error) {
            console.error("Sign-in failed:", error);
        }
    };

    return (
        <Box>
            <Header />
            <Box sx={{
                backgroundColor: '#E8E9EB',
                height: '100vh',
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center'
            }}>
                <Box
                    component="form"
                    onSubmit={handleSignIn}
                    sx={{
                        display: 'flex',
                        flexDirection: 'column',
                        justifyContent: 'center',
                        alignItems: 'center',
                        height: '200px',
                        width: '400px',
                        backgroundColor: '#E0DFD5',
                        borderRadius: '10px',
                        boxShadow: '0 5px 5px rgba(0, 0, 0, 0.3)',
                        '& > :not(style)': { m: 1, width: '25ch' },
                    }}
                    noValidate
                    autoComplete="off"
                >
                    <TextField
                        type="email"
                        label="Email"
                        color="warning"
                        variant="outlined"
                        value={email}
                        onChange={handleEmailChange}
                    />
                    <Button type="submit" variant="contained" color="warning">
                        Join Up
                    </Button>
                </Box>
            </Box>
        </Box>
    );
};

export default SignIn;
