ordinary_directory() {
  local count
  count=0

  for file in $( ls ); do
    ((count++))
  done

  local free
  free=$( df -h . | awk 'NR==2 {print $4}' )

  echo "free disk space: $free @ files in the directory: $count"
}


update_promt() {
  if [ -d ".git" ]; then
    count=$( git status --porcelain | wc -l )
    PS1="modified files in the git repository: $count %# "
  else
    PS1="$(ordinary_directory) %# "
  fi
}

precmd() {
  update_promt
}
