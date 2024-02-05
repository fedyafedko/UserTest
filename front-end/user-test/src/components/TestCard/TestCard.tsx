import { CheckCircleOutline } from "@mui/icons-material";
import { Box, Link, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import TestAPI from "../../api/TestAPI";
import { TestBody } from "../../api/type/TestBody";

const TestCard = () => {
    const [testData, setTestData] = useState<TestBody[]>([]);
    const userId = localStorage.getItem('userId');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const tests = await TestAPI.TestForUser(userId);
                setTestData(tests);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, []);

    return (
        <>
            {userId ? (
                <>
                    {testData.map(test => (
                        <Link
                            key={test.id}
                            href={`/test/${test.id}`}
                            sx={{
                                display: 'flex',
                                justifyContent: 'space-between',
                                alignItems: 'center',
                                margin: '5px',
                                backgroundColor: '#F1FAEE',
                                borderRadius: '5px',
                                height: '70px',
                                width: '100%',
                                textDecoration: 'none',
                                color: 'black',
                                pointerEvents: test.isFinished ? 'none' : 'auto',
                            }}
                        >
                            <Typography variant="h5" component="div" sx={{ marginLeft: '15px' }}>
                                {test.title}
                            </Typography>
                            <Typography variant="h6" component="div" sx={{ marginRight: '5px', fontSize: '14px' }}>
                                Max mark: {test.maxMark}
                            </Typography>
                            {test.isFinished && <CheckCircleOutline sx={{ marginRight: '10px', color: 'green' }} />}
                        </Link>
                    ))}
                </>
            ) : (
                <Typography variant="h6" sx={{ textAlign: 'center', marginTop: '20px' }}>
                    Please log in to view tests.
                </Typography>
            )}
        </>
    );

};

export default TestCard;
