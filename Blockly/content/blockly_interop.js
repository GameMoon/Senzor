
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
window.blocklyInterop = {
	loadBlockly: function(){
		global.Blockly = require('./blockly_compresed.js');
	},

	loadJS: function (content) {
		document.getElementsByTagName("head")[0].innerHTML += ("<script>" + content + "</script>");
		return true;
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
			var childrenBlocks = block.getChildren();
			if (childrenBlocks.length > 0) {
				var children = [];
				childrenBlocks.forEach(function (childBlock) {
					children.push(childBlock.id);
				});

				newBlock["childrenids"] = children;
			}
			else newBlock['childrenids'] = []

			blocks.push(newBlock);
		});

		return JSON.stringify(blocks);
		}
}