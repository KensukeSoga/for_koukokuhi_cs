package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj37RdProgramCondition;
import jp.co.isid.ham.common.model.Tbj37RdProgramDAO;
import jp.co.isid.ham.common.model.Tbj37RdProgramDAOFactory;
import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialCondition;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAOFactory;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialVO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationCondition;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationDAO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationDAOFactory;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * ���W�I�ԑg�o�^��ʓo�^Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RegisterRdProgramInfoManager {

    /** �V���O���g���C���X�^���X */
    private static RegisterRdProgramInfoManager _manager = new RegisterRdProgramInfoManager();

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private RegisterRdProgramInfoManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     * @return �C���X�^���X
     */
    public static RegisterRdProgramInfoManager getInstance() {
        return _manager;
    }

    /**
     * ���W�I�ԑg�o�^��ʏ���o�^����
     * @param vo ���W�I�ԑg�o�^��ʓo�^���VO
     * @return ���W�I�ԑgSEQNO(�V�K�p)
     * @throws HAMException
     */
    public BigDecimal registerRdProgramInfo(RegisterRdProgramInfoVO vo) throws HAMException {

        /* �r���`�F�b�N */
        if (!tbj37ExclusionCheck(vo)) {
            throw new HAMException("�r���G���[", "BJ-E0005");
        }
        if (vo.getTbj38UpdVo() != null && vo.getTbj38UpdVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38vo : vo.getTbj38UpdVo()) {
                if (!tbj38ExclusionCheck(tbj38vo)) {
                    throw new HAMException("�r���G���[", "BJ-E0005");
                }
            }
        }
        if (vo.getTbj38DelVo() != null && vo.getTbj38DelVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38vo : vo.getTbj38DelVo()) {
                if (!tbj38ExclusionCheck(tbj38vo)) {
                    throw new HAMException("�r���G���[", "BJ-E0005");
                }
            }
        }
        if (vo.getTbj39DelVo() != null && vo.getTbj39DelVo().size() != 0) {
            for (Tbj39RdProgramStationVO tbj39vo : vo.getTbj39DelVo()) {
                if (!tbj39ExclusionCheck(tbj39vo)) {
                    throw new HAMException("�r���G���[", "BJ-E0005");
                }
            }
        }
        if (vo.getTbj20UpdVo() != null && vo.getTbj20UpdVo().size() != 0) {
            for (Tbj20SozaiKanriListVO tbj20vo : vo.getTbj20UpdVo()) {
                if (!tbj20ExclusionCheck(tbj20vo)) {
                    throw new HAMException("�r���G���[", "BJ-E0005");
                }
            }
        }

        //���W�I�ԑgSEQNO(�V�K�p)
        BigDecimal rdSeqNo = BigDecimal.valueOf(0);

        /* �f�ވꗗ��� */
        Tbj20SozaiKanriListDAO tbj20Dao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();

        //�X�V
        if (vo.getTbj20UpdVo() != null && vo.getTbj20UpdVo().size() != 0) {
            for (Tbj20SozaiKanriListVO tbj20Vo : vo.getTbj20UpdVo()) {
                tbj20Dao.updateVO(tbj20Vo);
            }
        }

        /* ���W�I�ԑg��� */
        Tbj37RdProgramDAO tbj37Dao = Tbj37RdProgramDAOFactory.createTbj37RdProgramDAO();
        Tbj38RdProgramMaterialDAO tbj38Dao = Tbj38RdProgramMaterialDAOFactory.createTbj38RdProgramMaterialDAO();
        Tbj39RdProgramStationDAO tbj39Dao = Tbj39RdProgramStationDAOFactory.createTbj39RdProgramStationDAO();

        /* ���W�I�ԑg�ꗗ */
        //�ǉ�
        BigDecimal maxRdSeqNo = BigDecimal.valueOf(0);
        if (vo.getTbj37InsVo() != null && vo.getTbj37InsVo().size() != 0) {

            //���W�I�ԑgSEQNO�ő�l�擾
            Tbj37RdProgramCondition tbj37Cond = new Tbj37RdProgramCondition();
            List<Tbj37RdProgramVO> tbj37VoList = tbj37Dao.selectMaxRdSeqNo(tbj37Cond);
            maxRdSeqNo = tbj37VoList.get(0).getRDSEQNO();

            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37InsVo()) {
                tbj37Vo.setRDSEQNO(maxRdSeqNo);
                tbj37Dao.insertVO(tbj37Vo);

                //���W�I�ԑgSEQNO(�V�K�p)�ɃZ�b�g.
                rdSeqNo = maxRdSeqNo;
            }
        }

        //�X�V
        if (vo.getTbj37UpdVo() != null && vo.getTbj37UpdVo().size() != 0) {
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37UpdVo()) {
                tbj37Dao.updateVO(tbj37Vo);
            }
        }

        //�폜
        if (vo.getTbj37DelVo() != null && vo.getTbj37DelVo().size() != 0) {
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37DelVo()) {
                tbj37Dao.deleteVO(tbj37Vo);
            }
        }

        /* ���W�I�ԑg�f�� */
        //�ǉ�
        if (vo.getTbj38InsVo() != null && vo.getTbj38InsVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38Vo : vo.getTbj38InsVo()) {
                if (tbj38Vo.getRDSEQNO() == null) {
                    tbj38Vo.setRDSEQNO(maxRdSeqNo);
                }
                tbj38Dao.insertVO(tbj38Vo);
            }
        }
        //�X�V
        if (vo.getTbj38UpdVo() != null && vo.getTbj38UpdVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38Vo : vo.getTbj38UpdVo()) {
                tbj38Dao.updateVO(tbj38Vo);
            }
        }
        //�폜
        if (vo.getTbj38DelVo() != null && vo.getTbj38DelVo().size() != 0) {
            for (Tbj38RdProgramMaterialVO tbj38Vo : vo.getTbj38DelVo()) {
                tbj38Dao.deleteVO(tbj38Vo);
            }
        }

        /* ���W�I�ԑg�l�b�g�� */
        //�ǉ�
        if (vo.getTbj39InsVo() != null && vo.getTbj39InsVo().size() != 0) {
            for (Tbj39RdProgramStationVO tbj39Vo : vo.getTbj39InsVo()) {
                if (tbj39Vo.getRDSEQNO() == null) {
                    tbj39Vo.setRDSEQNO(maxRdSeqNo);
                }
                tbj39Dao.insertVO(tbj39Vo);
            }
        }
        //�폜
        if (vo.getTbj39DelVo() != null && vo.getTbj39DelVo().size() != 0) {
            for (Tbj39RdProgramStationVO tbj39Vo : vo.getTbj39DelVo()) {
                tbj39Dao.deleteVO(tbj39Vo);
            }
        }

        return rdSeqNo;
    }

    /**
     * ���W�I�ԑg���r���`�F�b�N
     * @param vo ���W�I�ԑg�o�^��ʓo�^���VO
     * @return boolean true: ����I���Afalse : �r���G���[
     * @throws HAMException
     */
    private boolean tbj37ExclusionCheck(RegisterRdProgramInfoVO vo) throws HAMException {

        //�X�V�E�폜�Ώۂ����݂��Ȃ��ꍇ�A�����I��
        if ((vo.getTbj37UpdVo() == null || vo.getTbj37UpdVo().size() == 0)
                && (vo.getTbj37DelVo() == null || vo.getTbj37DelVo().size() == 0)) {
            return true;
        }

        Tbj37RdProgramDAO dao = Tbj37RdProgramDAOFactory.createTbj37RdProgramDAO();
        Tbj37RdProgramCondition cond = new Tbj37RdProgramCondition();

        //�X�V
        if (vo.getTbj37UpdVo() != null && vo.getTbj37UpdVo().size() != 0) {

            //��r�pHashMap����
            HashMap<BigDecimal, Date> map = new HashMap<BigDecimal, Date>();

            //�X�V�ΏۑS�����[�v����
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37UpdVo()) {
                cond.setRdseqno(tbj37Vo.getRDSEQNO());

                //�Č���
                List<Tbj37RdProgramVO> list = dao.selectVO(cond);

                if (list != null && list.size() != 0) {
                    map.put(list.get(0).getRDSEQNO(), list.get(0).getUPDDATE());
                } else {
                    //�X�V�Ώۂ̔N���̃��W�I�ԑgSEQNO�����݂��Ȃ��ꍇ�A�r���G���[
                    return false;
                }
            }

            //�X�V�Ώۂ̃��W�I�ԑgSEQNO�ōX�V�������r
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37UpdVo()) {

                //�X�V�Ώۂ̍X�V�������������ʂ̍X�V�����̏ꍇ�A�r���G���[
                if (tbj37Vo.getUPDDATE().before(map.get(tbj37Vo.getRDSEQNO()))) {
                    return false;
                }
            }
        }

        //�폜
        if (vo.getTbj37DelVo() != null && vo.getTbj37DelVo().size() != 0) {

            //��r�pHashMap����
            HashMap<BigDecimal, Date> map = new HashMap<BigDecimal, Date>();

            //�폜�ΏۑS�����[�v����
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37DelVo()) {
                cond.setRdseqno(tbj37Vo.getRDSEQNO());

                //�Č���
                List<Tbj37RdProgramVO> list = dao.selectVO(cond);

                if (list != null && list.size() != 0) {
                    map.put(list.get(0).getRDSEQNO(), list.get(0).getUPDDATE());
                } else {
                    //�폜�Ώۂ̔N���̃��W�I�ԑgSEQNO�����݂��Ȃ��ꍇ�A�r���G���[
                    return false;
                }
            }

            //�폜�Ώۂ̃��W�I�ԑgSEQNO�ōX�V�������r
            for (Tbj37RdProgramVO tbj37Vo : vo.getTbj37DelVo()) {

                //�폜�Ώۂ̍X�V�������������ʂ̍X�V�����̏ꍇ�A�r���G���[
                if (tbj37Vo.getUPDDATE().before(map.get(tbj37Vo.getRDSEQNO()))) {
                    return false;
                }
            }
        }

        return true;
    }

    /**
     * ���W�I�ԑg�f�ޏ��r���`�F�b�N
     * @param vo ���W�I�ԑg�f��VO
     * @return boolean true: ����I���Afalse : �r���G���[
     * @throws HAMException
     */
    private boolean tbj38ExclusionCheck(Tbj38RdProgramMaterialVO vo) throws HAMException {

        Tbj38RdProgramMaterialDAO dao = Tbj38RdProgramMaterialDAOFactory.createTbj38RdProgramMaterialDAO();
        Tbj38RdProgramMaterialCondition cond = new Tbj38RdProgramMaterialCondition();

        //��r�pHashMap����
        HashMap<BigDecimal, Date> map = new HashMap<BigDecimal, Date>();

        cond.setRdseqno(vo.getRDSEQNO());
        cond.setYearmonth(vo.getYEARMONTH());
        cond.setWakuseq(vo.getWAKUSEQ());

        //�Č���
        List<Tbj38RdProgramMaterialVO> list = dao.selectVO(cond);

        if (list != null && list.size() != 0) {
            map.put(list.get(0).getWAKUSEQ(), list.get(0).getUPDDATE());
        } else {
            //�X�V�Ώۂ̔N���̘gSEQNO�����݂��Ȃ��ꍇ�A�r���G���[
            return false;
        }

        //�X�V�Ώۂ̍X�V�������������ʂ̍X�V�����̏ꍇ�A�r���G���[
        if (vo.getUPDDATE().before(map.get(vo.getWAKUSEQ()))) {
            return false;
        }

        return true;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǐ��r���`�F�b�N
     * @param vo ���W�I�ԑg�l�b�g��VO
     * @return boolean true: ����I���Afalse : �r���G���[
     * @throws HAMException
     */
    private boolean tbj39ExclusionCheck(Tbj39RdProgramStationVO vo) throws HAMException {

        Tbj39RdProgramStationDAO dao = Tbj39RdProgramStationDAOFactory.createTbj39RdProgramStationDAO();
        Tbj39RdProgramStationCondition cond = new Tbj39RdProgramStationCondition();

        //��r�pHashMap����
        HashMap<String, Date> map = new HashMap<String, Date>();

        //�폜�ΏۑS�����[�v����
        cond.setRdseqno(vo.getRDSEQNO());
        cond.setStationcd(vo.getSTATIONCD());

        //�Č���
        List<Tbj39RdProgramStationVO> list = dao.selectVO(cond);

        if (list != null && list.size() != 0) {
            map.put(list.get(0).getSTATIONCD(), list.get(0).getUPDDATE());
        } else {
            //�폜�Ώۂ̔N���̋ǃR�[�h�����݂��Ȃ��ꍇ�A�r���G���[
            return false;
        }

        //�폜�Ώۂ̍X�V�������������ʂ̍X�V�����̏ꍇ�A�r���G���[
        if (vo.getUPDDATE().before(map.get(vo.getSTATIONCD()))) {
            return false;
        }

        return true;
    }

    /**
     * �f�ވꗗ�r���`�F�b�N
     * @param vo ���W�I�ԑg�o�^��ʓo�^���VO
     * @return boolean true: ����I���Afalse : �r���G���[
     * @throws HAMException
     */
    private boolean tbj20ExclusionCheck(Tbj20SozaiKanriListVO vo) throws HAMException {

        Tbj20SozaiKanriListDAO dao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
        Tbj20SozaiKanriListCondition cond = new Tbj20SozaiKanriListCondition();

            //��r�pHashMap����
            HashMap<String, Date> map = new HashMap<String, Date>();

            //�X�V�ΏۑS�����[�v����
                cond.setSozaiym(vo.getSOZAIYM());
                cond.setRcode(vo.getRCODE());

                //�Č���
                List<Tbj20SozaiKanriListVO> list = dao.FindSozaiKanriByRCode(cond);

                if (list != null && list.size() != 0) {
                    map.put(list.get(0).getRCODE(), list.get(0).getUPDDATE());
                } else {
                    //�X�V�Ώۂ̔N���̗��R�[�h�����݂��Ȃ��ꍇ�A�r���G���[
                    return false;
                }

                //�X�V�Ώۂ̍X�V�������������ʂ̍X�V�����̏ꍇ�A�r���G���[
                if (vo.getUPDDATE().before(map.get(vo.getRCODE()))) {
                    return false;
                }

        return true;
    }

}
