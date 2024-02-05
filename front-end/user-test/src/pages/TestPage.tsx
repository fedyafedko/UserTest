import { Box, Button, Typography } from "@mui/material";
import Header from "../components/Header/Header";
import Test from "../components/Test/Test";

const TestPage = () => {
    return (
        <Box>
            <Header />
            <Box sx={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                margin: '20px',
                backgroundColor: '#F1FAEE',
                borderRadius: '5px',
                border: '1px solid #000',
                width: '700px',
                mx: 'auto',
            }}>
                <Typography variant="h5">Test</Typography>
            </Box>
            <Test />
        </Box>
    );
}

export default TestPage;