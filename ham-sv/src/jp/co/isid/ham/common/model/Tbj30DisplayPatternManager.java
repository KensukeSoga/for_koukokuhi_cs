package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * �ꗗ�\���p�^�[�����Ǘ�����
 * ����ݒ��ʂ��ł���܂ł̉��̎����ł���X�폜�����\������̈׎g�p���Ȃ��ł�������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 K.Fukuda)<BR>
 * </P>
 * @author K.Fukuda
 */
public class Tbj30DisplayPatternManager {

    /** �V���O���g���C���X�^���X */
    private static Tbj30DisplayPatternManager _manager = new Tbj30DisplayPatternManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private Tbj30DisplayPatternManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static Tbj30DisplayPatternManager getInstance() {
        return _manager;
    }

    /**
     * ��ʍ��ڕ\���񐧌�}�X�^���擾���܂�
     * @param cond ����
     * @return ��ʍ��ڕ\���񐧌�}�X�^
     * @throws HAMException
     */
    public Tbj30DisplayPatternResult findTbj30DisplayPattern(Tbj30DisplayPatternCondition cond) throws HAMException {

        // ��������
        Tbj30DisplayPatternResult result = new Tbj30DisplayPatternResult();

        Tbj30DisplayPatternDAO dpDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternVO condVo = new Tbj30DisplayPatternVO();
        condVo.setFORMID(cond.getHamid());
        condVo.setFORMID(cond.getFormid());
        condVo.setFORMID(cond.getViewid());
        Tbj30DisplayPatternVO list = dpDao.loadVO(condVo);

        result.setDisplayControlList(list);

        return result;
    }

    public void registerTbj30DisplayPattern(List<Tbj30DisplayPatternVO> voList) throws HAMException {

        Tbj30DisplayPatternDAO dpDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        for (int i = 0; i < voList.size(); i++) {
            try {
                dpDao.deleteVO(voList.get(i));
            } catch(UserException e) {
                //�Ƃ肠��������
            }
            dpDao.insertVO(voList.get(i));
        }
    }

}
