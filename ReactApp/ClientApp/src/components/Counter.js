import React, { useState, useEffect } from 'react';

export function Counter() {
    const [count, setCount] = useState(0);

    return (
        <div>
            <p>Naci�ni�to {count} razy</p>
            <button className="btn btn-primary" onClick={() => setCount(count + 1)}>Naci�nij mnie</button>
        </div>
    );
}