package jp.co.isid.ham.login.controller;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.login.model.AccountSecurityRoleCondition;
import jp.co.isid.ham.login.model.MprKengenCheckManager;
import jp.co.isid.ham.login.model.AccountSecurityRoleResult;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.nj.controller.command.Command;

/**
 * <P>
 * �Ɩ���v�Z�L�����e�B���[���擾�R�}���h
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/05/17 JSE K.Tamura)<BR>
 * </P>
 *
 * @author JSE K.Tamura
 */
public class AccountSecurityRoleGetCmd extends Command {

    private static final long serialVersionUID = -8766965615145025400L;

    /** �������ʃL�[ */
    private static final String RESULT_KEY = "RESULT_KEY";

    /** �������� */
    private AccountSecurityRoleCondition _condition;

    /**
     * �����������g�p���A�������������s���܂�
     *
     * @throws HAMException �����Ɏ��s�����ꍇ
     */
    public void execute() throws HAMException {

        // ���̓`�F�b�N
        checkInput();

//        // �Ǘ��҃��[�U�[��񌠌��̃`�F�b�N
//        Mhf31TntVO kanriUserInfo = getKanriUserInfo();
//
//        if (kanriUserInfo != null) {
//            getResult().set(RESULT_KEY, setResult(null, true, kanriUserInfo));
//            return;
//        }

        // �Ɩ���v�Z�L�����e�B���[���i���Ό����j�擾
        MprKengenCheckManager manager = MprKengenCheckManager.getInstance();
        //String relativeAuthority = manager.getAccountSecurityRole(_condition);
        String relativeAuthority = manager.getAccountSecurityRole(_condition);

//      // �f�[�^���Ȃ��ꍇ
//      if (StringUtil.trim(relativeAuthority).isEmpty()) {
//		throw new HAMException("�Ɩ���v�Z�L�����e�B���[���擾�G���[", "HB-W0107");//TODO �G���[�R�[�h
//		}

        // �ԋp�l�ݒ�
        //getResult().set(RESULT_KEY, setResult(relativeAuthority, false, kanriUserInfo));
        getResult().set(RESULT_KEY, setResult(relativeAuthority, false));
    }

    /**
     * ����������ݒ肵�܂�
     *
     * @param condition ��������
     */
    public void setAccountSecurityRoleCondition(AccountSecurityRoleCondition condition) {
        _condition = condition;
    }

    /**
     * �������ʂ�Ԃ��܂�
     *
     * @return ��������
     */
    public AccountSecurityRoleResult getAccountSecurityRoleResult() {
        return (AccountSecurityRoleResult) super.getResult().get(RESULT_KEY);
    }

    /**
     * �p�����[�^���̓`�F�b�N
     *
     * @throws HAMException �p�����[�^�w��G���[�̏ꍇ
     */
    private void checkInput() throws HAMException {

        if (StringUtil.isBlank(_condition.getAplId())) {
            throw new HAMException("�p�����[�^�w��G���[", "BJ-E0002");
        }
        if (StringUtil.isBlank(_condition.getEsqId())) {
            throw new HAMException("�p�����[�^�w��G���[", "BJ-E0002");
        }
        if (StringUtil.isBlank(_condition.getPassword())) {
            throw new HAMException("�p�����[�^�w��G���[", "BJ-E0002");
        }
        if (_condition.getSecurityInfo() == null) {
            throw new HAMException("�p�����[�^�w��G���[", "BJ-E0002");
        }
    }

//    /**
//     * �Ǘ��҃��[�U�[���̎擾
//     *
//     * @return �Ǘ��҃��[�U�[���
//     * @throws HAMException �������ɃG���[�����������ꍇ
//     */
//    private Mhf31TntVO getKanriUserInfo() throws HAMException {
//        // ESQID�̐ݒ�
//        _condition.setEsqId(_condition.getEsqId());
//
//        AccountSecurityRoleManager manager = AccountSecurityRoleManager.getInstance();
//        Mhf31TntVO kanriUserInfo = manager.findKanriUserInfo(_condition);
//        return kanriUserInfo;
//    }

//    /**
//     * �ԋp�l�ݒ�
//     *
//     * @param relativeAuthority ���Ό���
//     * @param notSecurityRoleFlag �Z�L�����e�B���[���擾�ΏۊO�t���O
//     * @param kanriUserKengen �Ǘ��҃��[�U�[��񌠌�
//     * @return �Ɩ���v�Z�L�����e�B���[���擾����
//     */
//    private AccountSecurityRoleResult setResult(String relativeAuthority, boolean notSecurityRoleFlag, Mhf31TntVO kanriUserInfo) {
//
//        AccountSecurityRoleResult result = new AccountSecurityRoleResult();
//        result.setRelativeAuthority(relativeAuthority);
//        result.setNotSecurityRoleFlag(notSecurityRoleFlag);
//        result.setKanriUserInfo(kanriUserInfo);
//        return result;
//    }
    /**
     * �ԋp�l�ݒ�
     *
     * @param relativeAuthority ���Ό���
     * @param notSecurityRoleFlag �Z�L�����e�B���[���擾�ΏۊO�t���O
     * @return �Ɩ���v�Z�L�����e�B���[���擾����
     */
    private AccountSecurityRoleResult setResult(String relativeAuthority, boolean notSecurityRoleFlag) {

        AccountSecurityRoleResult result = new AccountSecurityRoleResult();
        result.setRelativeAuthority(relativeAuthority);
        result.setNotSecurityRoleFlag(notSecurityRoleFlag);
        return result;
    }

}
