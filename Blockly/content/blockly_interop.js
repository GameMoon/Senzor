
var onresize = function (e) {
	// Compute the absolute coordinates and dimensions of blocklyArea.
	if (typeof blocklyArea === "undefined") return;

	var element = blocklyArea;
	var x = 0;
	var y = 0;
	do {
		x += element.offsetLeft;
		y += element.offsetTop;
		element = element.offsetParent;
	} while (element);
	// Position blocklyDiv over blocklyArea.
	blocklyDiv.style.left = x + 'px';
	blocklyDiv.style.top = y + 'px';
	blocklyDiv.style.width = blocklyArea.offsetWidth + 'px';
	blocklyDiv.style.height = blocklyArea.offsetHeight + 'px';
	Blockly.svgResize(window.workspace);
};
function blockModificationHandler(event) {
	if (
		event.type == Blockly.Events.BLOCK_CHANGE ||
		event.type == Blockly.Events.BLOCK_CREATE ||
		event.type == Blockly.Events.BLOCK_DELETE ||
		event.type == Blockly.Events.BLOCK_MOVE
	) {
		window.workSpaceInstance.invokeMethodAsync("UpdateBlocks");
	}
}

window.blocklyInterop = {

	passWorkspaceInstance: function (instance) {
		console.log(instance);
		window.workSpaceInstance = instance;
	},

	initBlockly: function () {
		var blocklyArea = document.getElementById('blocklyArea');
		var blocklyDiv = document.getElementById('blocklyDiv');
		var workspace = Blockly.inject(blocklyDiv,
			{ toolbox: document.getElementById('toolbox') });

		window.workspace = workspace;
		
		window.addEventListener('resize', window.onresize, false);
		onresize();
		Blockly.svgResize(workspace);
		workspace.addChangeListener(blockModificationHandler);
		return true;
	},

	loadBlock: function (name, jsonString) {
		return Blockly.Blocks[name] = {
			init: function () {
				this.jsonInit(JSON.parse(jsonString))
			}
		};
	},
	 getState: function () {
		var allBlock = Blockly.getMainWorkspace().getAllBlocks();

		var blocks = [];

		allBlock.forEach(function (block) {
			var newBlock = {
				"id": block.id,
				"type": block.type,
				'value': block.toString()
			};

			if (block.getInput(0)) {
				var blockInput = block.getInput(0).fieldRow[0];
				if (typeof blockInput.value_ != "undefined") newBlock['value'] = blockInput.value_;
				else if (typeof blockInput.text_ != "undefined") newBlock['value'] = blockInput.text_;
			}

			//Parent
			if (block.getParent() != null) newBlock['parentid'] = block.getParent().id;
			else newBlock['parentid'] = "";

			//Children
			
			var inputList = block.inputList;
			if (inputList.length > 0) {
				var inputs = [];

				inputList.forEach(function (input, index) {
					
					if (input.connection && input.connection.targetConnection) {
						inputs[index] = input.connection.targetConnection.getSourceBlock().id;
					}
					else inputs[index] = null;
				});

			
				newBlock["InputIds"] = inputs;
			}
			else newBlock['InputIds'] = []


			blocks.push(newBlock);
		});

		return JSON.stringify(blocks);
		}
}