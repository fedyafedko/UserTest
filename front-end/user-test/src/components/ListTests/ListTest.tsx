import { Box, Typography } from "@mui/material"
import TestCard from "../TestCard/TestCard"

const ListTest = () => {
    return (
        <Box sx={{
            display: 'flex',
            flexDirection: 'column', 
            alignItems: 'center',
            padding: '10px',
            backgroundColor: '#AFB7B8',
            borderRadius: '5px',
            height: '500px',
            width: '700px',
        
        }}>
            <TestCard />
        </Box>
    )
}

export default ListTest