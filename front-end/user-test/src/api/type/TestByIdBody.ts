interface TestByIdBody {
    id: string;
    title: string;
    maxMark: number;
    isFinished: boolean;
    tasks: Task[];
}

interface Task {
    id: string;
    testId: string;
    label: string;
    options: Option[];
}

interface Option {
    id: string;
    label: string;
    isCorrect: boolean;
}

export default TestByIdBody;