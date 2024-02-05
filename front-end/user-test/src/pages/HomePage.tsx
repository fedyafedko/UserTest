import { Box, Typography } from "@mui/material";
import Header from "../components/Header/Header";
import ListTest from "../components/ListTests/ListTest";

const HomePage = () => {
    return (
        <>
        <Header />
        <Box sx={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100%', padding: '61.5px'}}>
            <ListTest />
        </Box>
    </>
    );
};

export default HomePage;