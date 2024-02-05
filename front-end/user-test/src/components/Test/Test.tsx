import { Box, Button, FormControl, FormControlLabel, FormLabel, Radio, RadioGroup, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import TestByIdBody from "../../api/type/TestByIdBody";
import TestAPI from "../../api/TestAPI";
import { useParams } from "react-router-dom";
import UserAnswerBody from "../../api/type/UserAnswerBody";
import { useNavigate } from "react-router-dom";

const Test = () => {
    const navigate = useNavigate();
    const { id } = useParams();
    const [testData, setTestData] = useState<TestByIdBody>();
    const [selectedOptions, setSelectedOptions] = useState<UserAnswerBody>();
    const userId = localStorage.getItem('userId');

    useEffect(() => {
        const fetchData = async () => {
            try {
                const tests: TestByIdBody | undefined = await TestAPI.TestById(id);
                setTestData(tests);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        };

        fetchData();
    }, [id]);

    const handleRadioChange = (testId: string, optionId: string) => {
        setSelectedOptions((prevSelectedOptions) => ({
            ...prevSelectedOptions,
            userId: userId || '',
            testId: testId,
            optionsId: [...(prevSelectedOptions?.optionsId || []), optionId],
        }));
    };

    const handleButtonClick = async () => {
        try {
            const result = await TestAPI.AddAnswer(selectedOptions);
            if (result) {
                navigate("/");
            }
        } catch (error) {
            console.error("Error adding answer:", error);
        }
    };

    return (
        <>
            {testData?.tasks.map((task) => (
                <FormControl
                    key={task.label}
                    sx={{
                        display: 'flex',
                        justifyContent: 'center',
                        padding: '20px',
                        margin: '20px',
                        borderRadius: '5px',
                        border: '1px solid #000',
                        width: '700px',
                        mx: 'auto',
                    }}
                >
                    <FormLabel
                        id="demo-radio-buttons-group-label"
                        sx={{
                            color: 'black',
                            fontSize: '20px',
                        }}
                    >
                        {task.label}
                    </FormLabel>
                    <FormControl>
                        <FormLabel id="demo-radio-buttons-group-label"></FormLabel>
                        <RadioGroup
                            aria-labelledby="demo-radio-buttons-group-label"
                            defaultValue={task.options[0].id}
                            name={`radio-buttons-group-${task.id}`}
                            onChange={(event) => handleRadioChange(testData.id, event.target.value)}
                        >
                            {task.options.map((option) => (
                                <FormControlLabel
                                    key={option.id}
                                    value={option.id}
                                    control={<Radio />}
                                    label={option.label}
                                />
                            ))}
                        </RadioGroup>
                    </FormControl>
                </FormControl>
            ))}
            <Button
                sx={{
                    backgroundColor: '#EF8354',
                    borderRadius: '5px',
                    border: '1px solid #000',
                    width: '100px',
                    color: 'black',
                    margin: '20px 700px',
                    "&:hover": {
                        backgroundColor: '#E17706',
                    }
                }}
                onClick={handleButtonClick}
            >
                Finished
            </Button>
        </>
    );
};

export default Test;