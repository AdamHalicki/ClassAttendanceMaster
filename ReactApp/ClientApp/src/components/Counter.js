import React, { useState, useEffect } from 'react';

export function Counter() {
    const [count, setCount] = useState(0);

    return (
        <div>
            <p>Naciœniêto {count} razy</p>
            <button className="btn btn-primary" onClick={() => setCount(count + 1)}>Naciœnij mnie</button>
        </div>
    );
}