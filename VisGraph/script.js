// Define the nodes for the graph
var nodes = new vis.DataSet([
    { id: 1, label: "Node 1" },
    { id: 2, label: "Node 2" },
    { id: 3, label: "Node 3" },
  ]);
  
  // Define the edges for the graph
  var edges = new vis.DataSet([
    { from: 1, to: 2 },
    { from: 2, to: 3 },
    { from: 3, to: 1 },
  ]);
  
  // Create an object containing options for the graph
  var options = {
    nodes: {
      shape: "circle",
    },
    edges: {
      color: "#000000",
    },
  };
  
  // Create a network object and render the graph
  var container = document.getElementById("mynetwork");
  var data = {
    nodes: nodes,
    edges: edges,
  };
  var network = new vis.Network(container, data, options);

var nodes = null;
var edges = null;
var network = null;
var directionInput = document.getElementById("direction");

function destroy() {
  if (network !== null) {
    network.destroy();
    network = null;
  }
}

function draw() {
  destroy();
  nodes = [];
  edges = [];
  var connectionCount = [];

  // randomly create some nodes and edges
  for (var i = 0; i < 15; i++) {
    nodes.push({ id: i, label: String(i) });
  }
  edges.push({ from: 0, to: 1 });
  edges.push({ from: 0, to: 6 });
  edges.push({ from: 0, to: 13 });
  edges.push({ from: 0, to: 11 });
  edges.push({ from: 1, to: 2 });
  edges.push({ from: 2, to: 3 });
  edges.push({ from: 2, to: 4 });
  edges.push({ from: 3, to: 5 });
  edges.push({ from: 1, to: 10 });
  edges.push({ from: 1, to: 7 });
  edges.push({ from: 2, to: 8 });
  edges.push({ from: 2, to: 9 });
  edges.push({ from: 3, to: 14 });
  edges.push({ from: 1, to: 12 });
  nodes[0]["level"] = 0;
  nodes[1]["level"] = 1;
  nodes[2]["level"] = 3;
  nodes[3]["level"] = 4;
  nodes[4]["level"] = 4;
  nodes[5]["level"] = 5;
  nodes[6]["level"] = 1;
  nodes[7]["level"] = 2;
  nodes[8]["level"] = 4;
  nodes[9]["level"] = 4;
  nodes[10]["level"] = 2;
  nodes[11]["level"] = 1;
  nodes[12]["level"] = 2;
  nodes[13]["level"] = 1;
  nodes[14]["level"] = 5;

  // create a network
  var container = document.getElementById("mynetwork");
  var data = {
    nodes: nodes,
    edges: edges,
  };

  var options = {
    edges: {
      smooth: {
        type: "cubicBezier",
        forceDirection:
          directionInput.value == "UD" || directionInput.value == "DU"
            ? "vertical"
            : "horizontal",
        roundness: 0.4,
      },
    },
    layout: {
      hierarchical: {
        direction: directionInput.value,
      },
    },
    physics: false,
  };
  network = new vis.Network(container, data, options);

  // add event listeners
  network.on("select", function (params) {
    document.getElementById("selection").innerText =
      "Selection: " + params.nodes;
  });
}

  