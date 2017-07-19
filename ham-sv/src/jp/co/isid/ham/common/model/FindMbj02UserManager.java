package jp.co.isid.ham.common.model;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * �S���҃}�X�^Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/25 ���g)<BR>
 * </P>
 * @author ���g
 */
public class FindMbj02UserManager {

    /** �V���O���g���C���X�^���X */
    private static FindMbj02UserManager _manager = new FindMbj02UserManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindMbj02UserManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindMbj02UserManager getInstance() {
        return _manager;
    }

    /**
     * �S���҃}�X�^���������܂�
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    public FindMbj02UserResult findMbj02User(Mbj02UserCondition cond) throws HAMException {

        FindMbj02UserResult result = new FindMbj02UserResult();

        // ******************************************************
        // �S���҃}�X�^�̎擾
        // ******************************************************
        Mbj02UserDAO userDao = Mbj02UserDAOFactory.createMbj02UserDAO();
        result.setUserVo(userDao.selectVO(cond));

        return result;
    }
}
