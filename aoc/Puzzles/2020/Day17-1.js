var grid = []

function setup() {
    createCanvas(800, 800, WEBGL);

    cam1 = createCamera();
    cam1.setPosition(500, -500, 500);
    cam1.lookAt(0, 0, 0);

    // set variable for previously active camera:
    currentCamera = 1;

    for (let z = -3; z <= 3; z++) {
        for (let y = -3; y <= 3; y++) {
            for (let x = -3; x <= 3; x++) {
                let active = 0;
                if (x == 0 && y == -1 && z == 0) active = 1;
                if (x == 1 && y == 0 && z == 0) active = 1;
                if (x == -1 && y == 1 && z == 0) active = 1;
                if (x == 0 && y == 1 && z == 0) active = 1;
                if (x == 1 && y == 1 && z == 0) active = 1;
                grid.push([x, y, z, active]);
            }
        }
    }

    print(grid.length)
    //noLoop();
}

function draw() {
    background(200);
    orbitControl();
    /*
        let grid = [
            [-1, -1, 0, 0],
            [0, -1, 0, 1],
            [1, -1, 0, 0],
            [-1, 0, 0, 0],
            [0, 0, 0, 0],
            [1, 0, 0, 1],
            [-1, 1, 0, 1],
            [0, 1, 0, 1],
            [1, 1, 0, 1],
    
        ];
    */
    stroke(255, 0, 0);
    strokeWeight(1);
    line(-1000, 0, 0, 1000, 0, 0);

    stroke(0, 255, 0);
    line(0, -1000, 0, 0, 1000, 0);

    stroke(0, 0, 255);
    line(0, 0, -1000, 0, 0, 1000);

    stroke(255);

    DrawCubes(grid);
}

function DrawCubes(grid) {
    for (let i = 0; i < grid.length; i++) {
        let x = grid[i][0] * 50;
        let y = grid[i][1] * 50;
        let z = grid[i][2] * 50;
        let active = grid[i][3];

        push();

        if (active === 1) {
            stroke(0, 152, 94);
            fill(0, 102, 94);
        }
        else {
            stroke('rgba(100%,0%,0%,0.2)')
            //fill(255, 102, 94,0.1);
            fill('rgba(100%,30%,30%,0.01)');
        }
        translate(createVector(x, y, z))
        box(20);

        pop();
    }
}