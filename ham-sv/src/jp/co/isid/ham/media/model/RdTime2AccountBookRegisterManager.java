package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.common.model.Tbj12CampaignCondition;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailCondition;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g���o�^Manager
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/12/11 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class RdTime2AccountBookRegisterManager {

    /** �V���O���g���C���X�^���X */
    private static RdTime2AccountBookRegisterManager _manager = new RdTime2AccountBookRegisterManager();

    /** �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g��񌟍����� */
    private FindRdTime2AccountBookCondition _cond = null;
    /** �t�F�C�Y */
    private BigDecimal _phase = BigDecimal.valueOf(0);
    /** ���/���� */
    private String _term = null;

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private RdTime2AccountBookRegisterManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static RdTime2AccountBookRegisterManager getInstance() {
        return _manager;
    }

    /**
     * �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g���o�^
     * @param vo �c�ƍ�Ƒ䒠VO
     * @param cond �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g��񌟍�����
     * @throws HAMException
     */
    public void registerRdTimeInfo2AccountBook(List<Tbj02EigyoDaichoVO> vo, FindRdTime2AccountBookCondition cond) throws HAMException {

        //��������
        _cond = cond;

        //�t�F�C�Y
        _phase = _cond.getPhase();
        //��
        _term = DateUtil.getTerm(_cond.getYearMonth());

        Tbj02EigyoDaichoDAO tbj02dao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        AccountBookLogRegisterDAO accountBoolLogRegisterDao = AccountBookRegisterDAOFactory.createAccountBookLogRegisterDAO();

        MediaPlanRegisterDAO mediaRegisterDAO = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
        CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();

        //�X�V�Ώۂ̔}�̏󋵊Ǘ�NO���X�g
        List<BigDecimal> planNoList = new ArrayList<BigDecimal>();

        for (Tbj02EigyoDaichoVO tb02vo : vo) {

            //�c�ƍ�Ƒ䒠No�ő�l�擾
            List<Tbj02EigyoDaichoVO> tbj02VoList = tbj02dao.selectMaxDaichoNo();

            //�擾�ł��Ȃ��ꍇ
            if (tbj02VoList.size() == 0) {
                throw new HAMException("�o�^","BJ-E0001");
            }

            String insDaichoNo = String.format("%015d", Long.valueOf(tbj02VoList.get(0).getDAICHONO()) + 1);
            tb02vo.setDAICHONO(insDaichoNo);

            //------------------------�}�̏󋵊Ǘ��f�[�^�̂��߂̏���------------------------//
            //�}�̏󋵊Ǘ����擾
            List<Tbj01MediaPlanVO> tbj01VoList = getMediaPlan(tb02vo);

            //�}�̏󋵊Ǘ�VO
            //���֘A�e�[�u���X�V�p
            Tbj01MediaPlanVO tbj00NewVo = null;

            //�擾�ł���ꍇ
            if (tbj01VoList.size() != 0) {

                //�c�ƍ�Ƒ䒠�̔}�̏󋵊Ǘ�NO�Ɏ擾�����}�̏󋵊Ǘ�NO��t�^
                tb02vo.setMEDIAPLANNO(tbj01VoList.get(0).getMEDIAPLANNO());
                tbj00NewVo = tbj01VoList.get(0);
            } else {
                //�擾�ł��Ȃ��ꍇ

                //�L�����y�[���ꗗ�f�[�^�̎擾
                List<Tbj12CampaignVO> tbj12VoList = getCampaign(tb02vo);

                //�L�����y�[���ꗗVO
                //���֘A�e�[�u���X�V�p
                Tbj12CampaignVO tbj12NewVo = null;

                //------------------------�L�����y�[���ꗗ�̂��߂̏���------------------------//
                //�R�Â��L�����y�[�����擾�ł��Ȃ��Ƃ�
                if (tbj12VoList.size() != 0) {
                    //�擾�ł���ꍇ
                    tbj12NewVo = tbj12VoList.get(0);
                } else {
                    //�擾�ł��Ȃ��ꍇ

                    //�ЂƂ܂��`�����̃L�����y�[���ꗗ���쐬
                    //�\�Z����т̍��v�͔}�̏󋵊Ǘ��̍X�V���ɍs��
                    tbj12NewVo = createCampaignVO(tb02vo);

                    //�L�����y�[���f�[�^��o�^
                    campRegistDAO.insCampaignList(tbj12NewVo);
                }
                //------------------------�L�����y�[���ꗗ�̂��߂̏���------------------------//

                //�ЂƂ܂��`�����̔}�̏󋵊Ǘ��f�[�^���쐬����
                //�\�Z����т̍��v�́A�}�̏󋵊Ǘ��̍X�V�ň�C�ɍs��
                tbj00NewVo = createMediaPlanVO(tb02vo, tbj12NewVo);

                //�}�̏󋵊Ǘ��f�[�^��o�^
                mediaRegisterDAO.insMediaPlan(tbj00NewVo);

                //�c�ƍ�Ƒ䒠�̔}�̏󋵊Ǘ�NO�ɍ쐬�����}�̏󋵊Ǘ�NO��t�^
                tb02vo.setMEDIAPLANNO(tbj00NewVo.getMEDIAPLANNO());
            }
            //------------------------�}�̏󋵊Ǘ��f�[�^�̂��߂̏���------------------------//

            //�c�ƍ�Ƒ䒠�o�^
            tbj02dao.insertVO(tb02vo);

            //�y�o�^�z�ŉc�ƍ�Ƒ䒠���O�쐬
            accountBoolLogRegisterDao.insAccountBookHistory(insDaichoNo, HAMConstants.HISTORYKBN_REGSTER);

            //�X�V�Ώۂ̔}�̏󋵊Ǘ�NO���X�g���猻�ݓo�^�\��̔}�̏󋵊Ǘ�NO���擾
            int index = planNoList.indexOf(tb02vo.getMEDIAPLANNO());

            //������Ȃ�������ǉ�
            if (index == -1) {
                //�X�V�Ώۂ̔}�̏󋵊Ǘ����X�g�ɒǉ�
                planNoList.add(tb02vo.getMEDIAPLANNO());
            }
        }

        //�c�ƍ�Ƒ䒠���X�V���鑼�e�[�u���̍X�V
        for (BigDecimal planNo : planNoList) {

            CampaignRegisterDetailsDAO campDetailRegistDAO = CampaignRegisterDetailsDAOFactory.createCampaignRegisterDetailsDAO();

            //�X�V�Ώۂ̔}�̏󋵊Ǘ��f�[�^�̎擾
            Tbj01MediaPlanCondition tbj01cond = new Tbj01MediaPlanCondition();
            tbj01cond.setMediaplanno(planNo);
            Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
            List<Tbj01MediaPlanVO> mediaplanvolist = tbj01dao.findMediaPlanByMediaPlanNo(tbj01cond);

            Tbj01MediaPlanVO tbj01vo = mediaplanvolist.get(0);

            //�X�V�p�̔}�̏󋵊Ǘ��f�[�^���쐬
            tbj01vo = updateMediaPlanVO(tbj01vo, planNo);

            //�}�̏󋵊Ǘ��f�[�^���X�V
            mediaRegisterDAO.updMediaPlan(tbj01vo);

            //�X�V�Ώۂ̃L�����y�[���ꗗ�f�[�^�̎擾
            Tbj12CampaignDAO tbj12dao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
            List<Tbj12CampaignVO> tbj12VoList = tbj12dao.findCampaignListByCampCd(tbj01vo.getCAMPCD());
            Tbj12CampaignVO tbj12vo = tbj12VoList.get(0);

            //�X�V�p�̃L�����y�[��VO���쐬
            tbj12vo = updateCampaignVO(tbj12vo);

            //�L�����y�[���f�[�^���X�V
            campRegistDAO.updCampaignList(tbj12vo);

            Tbj13CampDetailCondition tbj13cond = new Tbj13CampDetailCondition();
            tbj13cond.setCampcd(tbj01vo.getCAMPCD());
            tbj13cond.setMediacd(tbj01vo.getMEDIACD());
            tbj13cond.setYoteiym(tbj01vo.getYOTEIYM());

            //�X�V�Ώۂ̃L�����y�[���ڍ׃f�[�^����x�폜���Ă���
            campDetailRegistDAO.delCampaignDetailsByCd(tbj13cond);

            Tbj13CampDetailVO tbj13vo = createCampDetailVO(tbj01vo);
            campDetailRegistDAO.insCampaignDetails(tbj13vo);
        }
    }

    /**
     * �L�����y�[���o�^VO�쐬
     * (�R�Â��L�����y�[����������Ȃ������ꍇ�̂ݎ��{)
     * @param tbj02vo �c�ƍ�Ƒ䒠VO
     * @return �L�����y�[���ꗗVO
     * @throws HAMException
     */
    private Tbj12CampaignVO createCampaignVO(Tbj02EigyoDaichoVO tbj02vo) throws HAMException {

        //�L�����y�[���R�[�h�ő�l�擾
        Tbj12CampaignDAO tbj12dao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> tbj12VoList = tbj12dao.findMaxCampCd();

        //�擾�ł��Ȃ��ꍇ
        if (tbj12VoList.size() == 0) {
            throw new HAMException("�o�^","BJ-E0032");
        }

        Tbj12CampaignVO tbj12vo = tbj12VoList.get(0);

        String maxCampNo = tbj12vo.getCAMPCD();
        maxCampNo =  maxCampNo.replace("CP", "");
        int No = Integer.parseInt(maxCampNo) + 1;

        //�L�����y�[���R�[�h
        tbj12vo.setCAMPCD("CP" + String.format("%1$05d", No));

        //�d�ʎԎ�R�[�h
        tbj12vo.setDCARCD(tbj02vo.getDCARCD());
        //�t�F�C�Y
        tbj12vo.setPHASE(_phase);

        //�\����ԊJ�n�A�\����ԏI��
        Calendar calendar = Calendar.getInstance();

        //������
        String termStartDate = DateUtil.getTermBegin(_cond.getYearMonth().replace("/", "") + "01") + "01";
        Date fromDate = DateUtil.toDate(termStartDate);

        //�����̏ꍇ
        if (_term.equals(HAMConstants.TERM_SECOND)) {
            calendar.setTime(fromDate);
            calendar.add(Calendar.MONTH, 6);
            fromDate = calendar.getTime();
        }

        //������
        calendar.setTime(fromDate);
        calendar.add(Calendar.MONTH, 6);
        calendar.add(Calendar.DAY_OF_MONTH, -1);

        //�\����ԊJ�n
        tbj12vo.setKIKANFROM(fromDate);
        //�\����ԏI��
        tbj12vo.setKIKANTO(calendar.getTime());

        //�L�����y�[����
        //�u<�Ԏ햼>XX��<��/��>���L�����y�[���v
        tbj12vo.setCAMPNM(tbj02vo.getDCARCD() + " " +_phase + "��" + _term + "���L�����y�[��");
        //�����\����z
        tbj12vo.setFSTBUDGET(BigDecimal.valueOf(0));    //�����\�Z�Ȃ̂�0
        //�\�Z���z
        tbj12vo.setBUDGET(tbj02vo.getGROSS());
        //�\�Z���z(�V)
        tbj12vo.setBUDGETHM(tbj02vo.getHMCOST());
        //���{���z
        tbj12vo.setACTUAL(tbj02vo.getGROSS());
        //���{���z(�V)
        tbj12vo.setACTUALHM(tbj02vo.getHMCOST());
        //���l
        tbj12vo.setMEMO("");
        //�}�̍쐬�σt���O
        tbj12vo.setBAITAIFLG("1");  //�쐬��
        //�f�[�^�쐬��
        tbj12vo.setCRTNM(tbj02vo.getCRTNM()); //�쐬��
        //�쐬�v���O����
        tbj12vo.setCRTAPL(tbj02vo.getCRTAPL());
        //�쐬�S����ID
        tbj12vo.setCRTID(tbj02vo.getCRTID());
        //�f�[�^�X�V��
        tbj12vo.setUPDNM(tbj02vo.getUPDNM());
        //�X�V�v���O����
        tbj12vo.setUPDAPL(tbj02vo.getUPDAPL());
        //�X�V�S����ID
        tbj12vo.setUPDID(tbj02vo.getUPDID());

        return tbj12vo;
    }

    /**
     * �}�̏󋵊Ǘ��o�^VO�쐬
     * (�R�Â��}�̏󋵊Ǘ�NO��������Ȃ������ꍇ�̂ݎ��{)
     * @param tbj02vo �c�ƍ�Ƒ䒠VO
     * @param tbj12vo �L�����y�[��VO
     * @return �}�̏󋵊Ǘ�VO
     * @throws HAMException
     */
    private Tbj01MediaPlanVO createMediaPlanVO(Tbj02EigyoDaichoVO tbj02vo, Tbj12CampaignVO tbj12vo) throws HAMException {

        //�}�̊Ǘ�No�ő�l�擾
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> tbj01VoList = tbj01dao.findMediaPlanMaxCd();

        //�擾�ł��Ȃ��ꍇ
        if (tbj01VoList.size() == 0) {
            throw new HAMException("�o�^","BJ-E0032");
        }

        Tbj01MediaPlanVO tbj01vo = tbj01VoList.get(0);

        //�����ŏI���擾
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(tbj02vo.getKIKANFROM());

        //������
        calendar.set(Calendar.DATE, 1);
        //������
        calendar.set(Calendar.DATE, calendar.getActualMaximum(Calendar.DATE));

        //�L�����y�[���R�[�h
        tbj01vo.setCAMPCD(tbj12vo.getCAMPCD());
        //�}�̊Ǘ�No
        tbj01vo.setMEDIAPLANNO(tbj01vo.getMEDIAPLANNO().add(BigDecimal.valueOf(1)));
        //�o�e�\��N��
        tbj01vo.setYOTEIYM(DateUtil.toDate(_cond.getYearMonth().replace("/", "") + "01"));
        //�n��R�[�h
        tbj01vo.setKEIRESTUCD(tbj02vo.getKEIRETSUCD());
        //�d�ʎԎ�R�[�h
        tbj01vo.setDCARCD(tbj02vo.getDCARCD());
        //�}�̃R�[�h
        tbj01vo.setMEDIACD(tbj02vo.getMEDIACD());
        //��p�v��No
        tbj01vo.setHIYOUNO(tbj02vo.getHIYOUNO());
        //�㗝�X��
        tbj01vo.setAGENCY("�d��");
        //�L������
        tbj01vo.setKENMEI(tbj12vo.getCAMPNM());
        //���L����
        tbj01vo.setMEMO("");
        //�t�F�C�Y
        tbj01vo.setPHASE(_phase);
        //��
        if (_term.equals(HAMConstants.TERM_FIRST)) {
            tbj01vo.setTERM(HAMConstants.TERM_STR_FIRST);   //���
        } else {
            tbj01vo.setTERM(HAMConstants.TERM_STR_SECOND);  //����
        }
        //�\����ԊJ�n
        tbj01vo.setKIKANFROM(tbj01vo.getYOTEIYM()); //YYYY/MM/01
        //�\����ԏI��
        tbj01vo.setKIKANTO(calendar.getTime()); //YYYY/MM/�ŏI��
        //�g�l���F
        tbj01vo.setHMOK("0");   //"0"�Œ�
        //�}�̔���
        tbj01vo.setBUYEROK("0");    //"0"�Œ�
        //�\�Z���z
        tbj01vo.setBUDGET(tbj02vo.getGROSS());
        //�\�Z���z(�V)
        tbj01vo.setBUDGETHM(tbj02vo.getHMCOST());
        //���{���z
        tbj01vo.setACTUAL(tbj02vo.getGROSS());
        //���{���z(�V)
        tbj01vo.setACTUALHM(tbj02vo.getHMCOST());
        //�������z
        tbj01vo.setADJUSTMENT(BigDecimal.valueOf(0));
        //�\�����z
        tbj01vo.setDIFAMT(BigDecimal.valueOf(0));
        //�\�����z(�V)
        tbj01vo.setDIFAMTHM(BigDecimal.valueOf(0));
        //�\�Z�o�^�t���O
        tbj01vo.setBUDGETUPDFLG("1");   //�c�ƍ�Ƒ䒠
        //�f�[�^�쐬��
        tbj01vo.setCRTNM(tbj02vo.getCRTNM());
        //�쐬�v���O����
        tbj01vo.setCRTAPL(tbj02vo.getCRTAPL());
        //�쐬�S����ID
        tbj01vo.setCRTID(tbj02vo.getCRTID());
        //�f�[�^�X�V��
        tbj01vo.setUPDNM(tbj02vo.getUPDNM());
        //�X�V�v���O����
        tbj01vo.setUPDAPL(tbj02vo.getUPDAPL());
        //�X�V�S����ID
        tbj01vo.setUPDID(tbj02vo.getUPDID());

        return tbj01vo;
    }

    /**
     * �}�̏󋵊Ǘ��f�[�^�X�VVO�쐬
     * (�R�Â��}�̏󋵊Ǘ�NO���ݎ��̂ݎ��{)
     * @param tbj01vo �}�̏󋵊Ǘ�VO
     * @param planNo bai�擾�����c�Ƒ䒠VO
     * @return �X�V�p�}�̏󋵊Ǘ��f�[�^
     * @throws HAMException
     */
    private Tbj01MediaPlanVO updateMediaPlanVO(Tbj01MediaPlanVO tbj01vo, BigDecimal planNo) throws HAMException {

        //�c�ƍ�Ƒ䒠����A�R�Â��}�̏󋵊Ǘ�NO�ɑ΂���AHM�R�X�g��GROSS�����̍��v���擾
        Tbj02EigyoDaichoDAO tbj02dao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        List<Tbj02EigyoDaichoVO> tbj02VoList = tbj02dao.FindEigyoDaichoFeeSUM(planNo.toString());

        //�擾�ł��Ȃ��ꍇ
        if (tbj02VoList.size() == 0) {
            throw new HAMException("�o�^","BJ-E0032");
        }

        //�\�Z���z
        tbj01vo.setBUDGET(tbj02VoList.get(0).getGROSS());
        //�\�Z���z(�V)
        tbj01vo.setBUDGETHM(tbj02VoList.get(0).getHMCOST());
        //���{���z
        tbj01vo.setACTUAL(tbj02VoList.get(0).getGROSS());
        //���{���z(�V)
        tbj01vo.setACTUALHM(tbj02VoList.get(0).getHMCOST());
        //�\�����z
        tbj01vo.setDIFAMT(tbj01vo.getBUDGET().subtract(tbj01vo.getACTUAL())); //0
        //�\�����z(�V)
        tbj01vo.setDIFAMTHM(tbj01vo.getBUDGETHM().subtract(tbj01vo.getACTUALHM())); //0

        return tbj01vo;
    }

    /**
     * �L�����y�[���f�[�^�X�V�pVO�쐬
     * (�R�Â��L�����y�[���f�[�^�����ݎ��̂ݎ��{�j
     * @param tbj12vo �L�����y�[��VO
     * @return �X�V�pVO
     * @throws HAMException
     */
    private Tbj12CampaignVO updateCampaignVO(Tbj12CampaignVO tbj12vo) throws HAMException {

        //�Ώۂ̃L�����y�[���R�[�h�����}�̏󋵊Ǘ��f�[�^�̍��v���擾
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> tbj01VoList = tbj01dao.findMediaPlanByCampCdSUM(tbj12vo.getCAMPCD());

        //�擾�ł��Ȃ��ꍇ
        if (tbj01VoList.size() == 0) {
            throw new HAMException("�o�^","BJ-E0032");
        }

        //�\�Z���z�A���{���z
        tbj12vo.setACTUAL(tbj01VoList.get(0).getACTUAL());
        tbj12vo.setACTUALHM(tbj01VoList.get(0).getACTUALHM());
        tbj12vo.setBUDGET(tbj01VoList.get(0).getBUDGET());
        tbj12vo.setBUDGETHM(tbj01VoList.get(0).getBUDGETHM());

        return tbj12vo;
    }

    /**
     * �o�^�p�L�����y�[���ڍ׃f�[�^���쐬
     * (Delete/Insert���s�����߁A����쐬)
     * @param tbj01vo �}�̏󋵊Ǘ�VO
     * @return �L�����y�[������VO
     * @throws HAMException
     */
    private Tbj13CampDetailVO createCampDetailVO(Tbj01MediaPlanVO tbj01vo) throws HAMException {

        Tbj13CampDetailVO tbj13vo = new Tbj13CampDetailVO();

        //���ԂƃL�����y�[���R�[�h�Ō������A���������f�[�^�̍��v�l���擾
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        Tbj01MediaPlanCondition tbj01cond = new Tbj01MediaPlanCondition();
        tbj01cond.setCampcd(tbj01vo.getCAMPCD());
        tbj01cond.setYoteiym(tbj01vo.getYOTEIYM());
        tbj01cond.setMediacd(tbj01vo.getMEDIACD());
        List<Tbj01MediaPlanVO> mediavolist = tbj01dao.findMediaPlanSUMByCdAndMonth(tbj01cond);

        //�擾�ł��Ȃ��ꍇ
        if (mediavolist.size() == 0) {
            throw new HAMException("�o�^","BJ-E0032");
        }

        Tbj01MediaPlanVO tbj01SumVo = mediavolist.get(0);

        //�L�����y�[���R�[�h
        tbj13vo.setCAMPCD(tbj01vo.getCAMPCD());
        //�d�ʎԎ�R�[�h
        tbj13vo.setDCARCD(tbj01vo.getDCARCD());
        //�}�̃R�[�h
        tbj13vo.setMEDIACD(tbj01vo.getMEDIACD());
        //�t�F�C�Y
        tbj13vo.setPHASE(tbj01vo.getPHASE());
        //�o�e�\��N��
        tbj13vo.setYOTEIYM(tbj01vo.getYOTEIYM());
        //�\����ԊJ�n
        tbj13vo.setKIKANFROM(tbj01vo.getKIKANFROM());
        //�\����ԏI��
        tbj13vo.setKIKANTO(tbj01vo.getKIKANTO());
        //�\�Z���z
        tbj13vo.setBUDGET(tbj01SumVo.getBUDGET());
        //�\�Z���z(�V)
        tbj13vo.setBUDGETHM(tbj01SumVo.getBUDGETHM());
        //�f�[�^�쐬��
        tbj13vo.setCRTNM(tbj01vo.getCRTNM());
        //�쐬�v���O����
        tbj13vo.setCRTAPL(tbj01vo.getCRTAPL());
        //�쐬�S����ID
        tbj13vo.setCRTID(tbj01vo.getCRTID());
        //�f�[�^�X�V��
        tbj13vo.setUPDNM(tbj01vo.getUPDNM());
        //�X�V�v���O����
        tbj13vo.setUPDAPL(tbj01vo.getUPDAPL());
        //�X�V�S����ID
        tbj13vo.setUPDID(tbj01vo.getUPDID());

        return tbj13vo;
    }

    /**
     * �o�^����c�ƍ�Ƒ䒠�f�[�^�ɕR�Â���L�����y�[�����擾
     * @param vo �c�ƍ�Ƒ䒠VO
     * @return �L�����y�[��VO
     * @throws HAMException
     */
    private List<Tbj12CampaignVO> getCampaign(Tbj02EigyoDaichoVO vo) throws HAMException {

        Tbj12CampaignCondition tbj12cond = new Tbj12CampaignCondition();
        Tbj12CampaignDAO tbj12dao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        tbj12cond.setDcarcd(vo.getDCARCD());
        tbj12cond.setPhase(_phase);
        tbj12cond.setKikanfrom(vo.getKIKANFROM());
        tbj12cond.setKikanto(vo.getKIKANTO());
        return tbj12dao.findCampaignCd(tbj12cond);
    }

    /**
     * �o�^����c�ƍ�Ƒ䒠�f�[�^�ɕR�Â���}�̏󋵊Ǘ��f�[�^���擾
     * @param vo �c�ƍ�Ƒ䒠VO
     * @return �}�̏󋵊Ǘ�VO
     * @throws HAMException
     */
    private List<Tbj01MediaPlanVO> getMediaPlan(Tbj02EigyoDaichoVO vo) throws HAMException {

        Tbj01MediaPlanCondition tbj01cond = new Tbj01MediaPlanCondition();
        Tbj01MediaPlanDAO tbj01dao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        tbj01cond.setDcarcd(vo.getDCARCD());
        tbj01cond.setMediacd(vo.getMEDIACD());
        tbj01cond.setPhase(_phase);
        tbj01cond.setTerm(_term);
        tbj01cond.setKikanfrom(vo.getKIKANFROM());
        tbj01cond.setKikanto(vo.getKIKANTO());
        return tbj01dao.findMediaPlanNo(tbj01cond);
    }

}
