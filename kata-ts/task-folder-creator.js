var fs = require('fs');
const yargs = require('yargs/yargs');
const { hideBin } = require('yargs/helpers');
const argv = yargs(hideBin(process.argv))
  .command('task', 'task name')
  .demand('task')
  .argv;

const taskName = argv.task.split(' ').map(s => s.toLowerCase()).join('-');
const tasksFolder = "./src/tasks";

const tsTemplate =
`export const func = () => { };
`

const tsTestTemplate =
`import { func } from "./${taskName}";

describe("${taskName}", () => {
  it.todo("example 1");
});
`

const readmeTemplate =
`# [Task Name](Link-to-task)

## Условие

## Примеры

\`\`\`bash
# Пример 1

\`\`\`

\`\`\`bash
# Пример 2


\`\`\`
`

const dir = `${tasksFolder}/${taskName}`

if (!fs.existsSync(dir)){
  fs.mkdirSync(dir);
}

fs.writeFileSync(`${dir}/${taskName}.ts`, tsTemplate);
fs.writeFileSync(`${dir}/${taskName}.test.ts`, tsTestTemplate);
fs.writeFileSync(`${dir}/README.md`, readmeTemplate);
