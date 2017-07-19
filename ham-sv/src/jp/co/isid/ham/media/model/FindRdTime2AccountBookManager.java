package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoCondition;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAO;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoDAOFactory;
import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;

/**
 * <P>
 * �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g��񌟍�Manager�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/12/11 HLC S.Fujimoto)<BR>
 * �EJASRAC�s��Ή�(2016/1/13 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdTime2AccountBookManager {

    /** �V���O���g���C���X�^���X */
    private static FindRdTime2AccountBookManager _manager = new FindRdTime2AccountBookManager();

    /** �}�̃R�[�h(���W�I�^�C��) */
    private static final String MEDIA_RADIOTIME = "M05";

    /**
     * �V���O���g���ׁ̈A�C���X�^���X�����֎~���܂�
     */
    private FindRdTime2AccountBookManager() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static FindRdTime2AccountBookManager getInstance() {
        return _manager;
    }

    /**
     * �c�ƍ�Ƒ䒠�o�^�pVO���쐬
     * @param cond ��������
     * @return �c�ƍ�Ƒ䒠�o�^�pVO
     * @throws HAMException
     */
    public List<Tbj02EigyoDaichoVO> FindRdTime2AccountBook(FindRdTime2AccountBookCondition cond) throws HAMException {

        //���ɓ������W�I�^�C����񂪉c�ƍ�Ƒ䒠�ɂ��邩�`�F�b�N
        Tbj02EigyoDaichoDAO tbj02dao = Tbj02EigyoDaichoDAOFactory.createTbj02EigyoDaichoDAO();
        Tbj02EigyoDaichoCondition tbj02cond = new Tbj02EigyoDaichoCondition();
        tbj02cond.setSeikyuym(DateUtil.toDate(cond.getYearMonth().replace("/", "") + "01"));
        tbj02cond.setMediacd(MEDIA_RADIOTIME);
        List<Tbj02EigyoDaichoVO> tbj02VoList = tbj02dao.selectVO(tbj02cond);

        if (tbj02VoList.size() != 0) {
            throw new HAMException("�o�^","BJ-W0438");
        }

        //�������擾
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(tbj02cond.getSeikyuym());  //������
        calendar.add(Calendar.MONTH, 1);    //��������
        calendar.add(Calendar.DATE, -1);    //��������

        //�c�ƍ�Ƒ䒠�o�^���쐬
        //������
        tbj02VoList.clear();

        //�c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g��񌟍�
        FindRdTime2AccountBookDAO dao = FindRdTime2AccountBookDAOFactory.createFindRdTime2AccountBookDAO();
        //�J�n���t�Ɍ������Z�b�g
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy/MM/dd");
        cond.setStartDate(sdf.format(tbj02cond.getSeikyuym()));
        //�I�����t�Ɍ������Z�b�g
        cond.setEndDate(sdf.format(calendar.getTime()));

        List<FindRdTime2AccountBookVO> voList = dao.findRdTime2AccountBookinfo(cond);

        //�擾�ł��Ȃ��ꍇ�A�����I��
        if (voList.size() == 0) {
            return tbj02VoList;
        }

        //�c�ƍ�Ƒ䒠�̍ő�\�[�g���擾
        //������
        tbj02cond.setKikanfrom(tbj02cond.getSeikyuym());
        //������
        tbj02cond.setKikanto(calendar.getTime());
        BigDecimal tbj02MaxSortNo = tbj02dao.FindMaxSortNo(tbj02cond).get(0).getSORTNO();

        //���z����HashMap�쐬
        Map<BigDecimal, BigDecimal> monthAmtMap = new HashMap<BigDecimal, BigDecimal>();    //���v���z
        Map<BigDecimal, BigDecimal> monthCntMap = new HashMap<BigDecimal, BigDecimal>();    //����
        Map<BigDecimal, Map<String, BigDecimal>> monthCarMap = new HashMap<BigDecimal, Map<String, BigDecimal>>();    //�Ԏ�}�b�v

        for (FindRdTime2AccountBookVO vo : voList) {

            //���z�����̏ꍇ
            if (vo.getSALESPRICEDIV().equals(HAMConstants.SALES_PRICE_DIV_MONTLY)) {

                //���v���z
                if (!monthAmtMap.containsKey(vo.getRDSEQNO())) {
                    monthAmtMap.put(vo.getRDSEQNO(), vo.getSALESPRICE());
                    monthCntMap.put(vo.getRDSEQNO(), BigDecimal.valueOf(0));
                } else {
                    //BigDecimal cnt = monthCntMap.get(vo.getRDSEQNO());
                }

                //�Ԏ�}�b�v
                Map<String, BigDecimal> monthCarCntMap = monthCarMap.get(vo.getRDSEQNO());
                if (monthCarMap.get(vo.getRDSEQNO()) == null) {
                    monthCarCntMap = new HashMap<String, BigDecimal>();
                    monthCarCntMap.put(vo.getDCARCD(), vo.getCNT());
                    monthCarMap.put(vo.getRDSEQNO(),  monthCarCntMap);
                } else {
                    BigDecimal cnt = monthCarCntMap.get(vo.getDCARCD());
                    if (cnt == null) {
                        cnt = BigDecimal.valueOf(0);
                    }
                    monthCarCntMap.put(vo.getDCARCD(), cnt.add(vo.getCNT()));
                    monthCarMap.put(vo.getRDSEQNO(),  monthCarCntMap);
                }

                //����
                monthCntMap.put(vo.getRDSEQNO(), monthCntMap.get(vo.getRDSEQNO()).add(vo.getCNT()));
            }
        }

        //���z����HashMap����1�񓖂���̒P�����擾
        Map<BigDecimal, BigDecimal> monthPerAmtMap = new HashMap<BigDecimal, BigDecimal>();
        for (BigDecimal key : monthAmtMap.keySet()) {
            //���z
            BigDecimal amount = monthAmtMap.get(key);
            //����
            BigDecimal count = monthCntMap.get(key);
            //�Ԏ탊�X�g
            Map<String, BigDecimal> carCntMap = monthCarMap.get(key);

            //�P���Z�o
            BigDecimal unitAmt = BigDecimal.valueOf(0);
            if (carCntMap.size() == 1) {
                //1�Ԏ�̏ꍇ�͍��v���z��P���Ƃ���
                unitAmt = amount;
            } else {
                //�P���Z�o(�؂�グ)
                unitAmt = amount.divide(count, 0, BigDecimal.ROUND_UP);
            }

            monthPerAmtMap.put(key, unitAmt);
        }

        //�c�ƍ�Ƒ䒠VO�쐬
        int i = 0;
        for (FindRdTime2AccountBookVO vo : voList) {

            Tbj02EigyoDaichoVO tbj02vo = new Tbj02EigyoDaichoVO();

            //�}�̊Ǘ�No
            tbj02vo.setMEDIAPLANNO(null);
            //�䒠�L�[
            tbj02vo.setDAICHONO(null);
            //IMP�L�[
            tbj02vo.setIMPKEY(null);
            //�����N��
            tbj02vo.setSEIKYUYM(DateUtil.toDate(cond.getYearMonth().replace("/", "") + "01"));
            //�}�̃R�[�h
            tbj02vo.setMEDIACD(MEDIA_RADIOTIME);//���W�I�^�C��
            //�}�̎�ʃR�[�h
            tbj02vo.setMEDIASCD(null);
            //�}�̎�ʖ�
            tbj02vo.setMEDIASNM(vo.getRDSTATION());//�����Ǘ���
            //�n��R�[�h
            tbj02vo.setKEIRETSUCD(vo.getKEIRETSUCD());
            //�d�ʎԎ�R�[�h
            tbj02vo.setDCARCD(vo.getDCARCD());

            //��p�v��No�A���No
            List<Mbj09HiyouVO> mbj09VoList = getHiyouInfo(vo, cond);
            if (mbj09VoList == null || mbj09VoList.size() == 0) {
                //�擾�ł��Ȃ��ꍇ
                tbj02vo.setHIYOUNO(null);
                tbj02vo.setKIKAKUNO(null);
            } else {
                //�擾�ł���ꍇ
                tbj02vo.setHIYOUNO(mbj09VoList.get(0).getHIYOUNO());
                tbj02vo.setKIKAKUNO(mbj09VoList.get(0).getKIKAKUNO());
            }

            //�L�����y�[����
            tbj02vo.setCAMPAIGN(vo.getPROGRAMNM());
            //���e���
            tbj02vo.setNAIYOHIMOKU(vo.getMEDIANM());
            //�X�y�[�X�i�V���̂݁j
            tbj02vo.setSPACE(null);
            //���[�i�V���̂݁j
            tbj02vo.setNPDIVISION(null);
            //�f�ڔŁi�V���̂݁j
            tbj02vo.setPUBLISHVER(null);
            //�L�G�敪�i�V���̂݁j
            tbj02vo.setSYMBOLDIVISION(null);
            //�f�ږʁi�V���̂݁j
            tbj02vo.setPOSTEDSURFACE(null);
            //�P�ʁi�V���̂݁j
            tbj02vo.setUNIT(null);
            //�_��敪�i�V���̂݁j
            tbj02vo.setCONTRACTDIVISION(null);

            /* 2016/1/13 JASRAC�s��Ή� HLC K.Soga MOD Start */
            //���ԊJ�n
            //���������Z�b�g
//            Date startDate = DateUtil.toDate(cond.getYearMonth().replace("/", "") + "01");
//            if (startDate.compareTo(vo.getSTARTDATE()) < 0) {
//                startDate = vo.getSTARTDATE();
//            }
            //���ԊJ�n
            //���������Z�b�g
            Date startDate = vo.getSTARTDATE();

            //�������������J�n���̏ꍇ�A�����J�n�������ԊJ�n���ɃZ�b�g
            if (startDate.compareTo(DateUtil.toDate(cond.getStartDate().replace("/", ""))) < 0) {
                startDate = DateUtil.toDate(cond.getStartDate().replace("/", ""));
            }
            /* 2016/1/13 JASRAC�s��Ή� HLC K.Soga MOD End */

            tbj02vo.setKIKANFROM(startDate);


            /* 2016/1/13 JASRAC�s��Ή� HLC K.Soga MOD Start */
            //���ԏI��
            //�������擾
//            calendar.setTime(tbj02vo.getKIKANFROM());
//            calendar.add(Calendar.MONTH, 1);    //��������
//            calendar.add(Calendar.DATE, -1);    //��������
//            Date endDate = calendar.getTime();
//            if (vo.getENDDATE().compareTo(endDate) < 0) {
//                endDate = vo.getENDDATE();
//            }

            //���ԏI��
            //�������擾
            Date endDate = vo.getENDDATE();

            //�����I�������������̏ꍇ�A�����I���������ԏI�����ɃZ�b�g
            if (endDate.compareTo(DateUtil.toDate(cond.getEndDate().replace("/", ""))) > 0) {
                endDate = DateUtil.toDate(cond.getEndDate().replace("/", ""));
            }
            /* 2016/1/13 JASRAC�s��Ή� HLC K.Soga MOD End */

            tbj02vo.setKIKANTO(endDate);

            //�������̓t���O
            tbj02vo.setGENKAFLG(null);

            //�O���X���z
            if (vo.getSALESPRICEDIV().equals(HAMConstants.SALES_PRICE_DIV_SECOND20)) {
                //20�b�P��
                tbj02vo.setGROSS(vo.getSALESPRICE().multiply(vo.getCNT()));
            } else if (vo.getSALESPRICEDIV().equals(HAMConstants.SALES_PRICE_DIV_MONTLY)) {
                //�c�z
                BigDecimal amt = monthAmtMap.get(vo.getRDSEQNO());
                //�P��
                BigDecimal unitAmt = monthPerAmtMap.get(vo.getRDSEQNO());
                //�Ԏ탊�X�g
                Map<String, BigDecimal> carMap = monthCarMap.get(vo.getRDSEQNO());

                if (carMap.size() != 1) {
                        unitAmt = unitAmt.multiply(carMap.get(vo.getDCARCD()));
                }

            //�c�z�|�P�����P���̏ꍇ
            if (unitAmt.compareTo(amt) > 0) {
                unitAmt = amt;
            }
                tbj02vo.setGROSS(unitAmt);
                monthAmtMap.put(vo.getRDSEQNO(), amt.subtract(unitAmt));
            }

            //�d�ʒl����
            tbj02vo.setDNEBIKIRITSU(BigDecimal.valueOf(17));
            //�d�ʒl���z
            //���O���X���z��17%�A�؎̂�
            BigDecimal discount = tbj02vo.getGROSS().multiply(tbj02vo.getDNEBIKIRITSU().divide(BigDecimal.valueOf(100).setScale(0, BigDecimal.ROUND_DOWN)));
            tbj02vo.setDNEBIKIGAKU(discount);
            //H�V���f���R�X�g
            tbj02vo.setHMCOST(tbj02vo.getGROSS().subtract(discount));
            //�c�Ɛ\�����v��
            tbj02vo.setAPLRIEKIRITSU(BigDecimal.valueOf(0));
            //�c�Ɛ\�����v�z
            tbj02vo.setAPLRIEKIGAKU(BigDecimal.valueOf(0));
            //�}�̎Е����z
            tbj02vo.setMEDIAHARAI(tbj02vo.getGROSS());
            //�}�̃}�[�W����
            tbj02vo.setMEDIAMARGINRITSU(tbj02vo.getDNEBIKIRITSU());
            //�}�̃}�[�W���z
            tbj02vo.setMEDIAMARGINGAKU(tbj02vo.getDNEBIKIGAKU());
            //�}�̌���
            tbj02vo.setMEDIAGENKA(tbj02vo.getHMCOST());
            //�戵���v�z
            tbj02vo.setTORIRIEKI(BigDecimal.valueOf(0));
            //�ʏ험�v�z���z
            tbj02vo.setRIEKIHAIBUN(BigDecimal.valueOf(0));
            //�ʏ���Η��v�z
            //���O���X���z��2%�A�؎̂�
            tbj02vo.setNAIKINRIEKI(tbj02vo.getGROSS().multiply(BigDecimal.valueOf(2).divide(BigDecimal.valueOf(100).setScale(0, BigDecimal.ROUND_DOWN))));
            //�U�֗��v�z���z
            tbj02vo.setFURIKAERIEKI(tbj02vo.getNAIKINRIEKI());
            //�c�Ɨv���z
            tbj02vo.setEIGYOYOIN(BigDecimal.valueOf(0));
            //�U�֗��v�z���z2
            tbj02vo.setFURIKAERIEKI2(null);
            //�e���r�^�C���}�̎Е��P��
            tbj02vo.setTVTMEDIATANKA(null);
            //�e���r�^�C��HM�P��
            tbj02vo.setTVTHMTANKA(null);
            //�F�����i�V���̂݁j
            tbj02vo.setCOLORFEE(null);
            //�w�藿�i�V���̂݁j
            tbj02vo.setDESIGNATIONFEE(null);
            //��A�ŗ��i�V���̂݁j
            tbj02vo.setDOUBLEFEE(null);
            //�g�֗��i�V���̂݁j
            tbj02vo.setRECLASSIFICATIONFEE(null);
            //�ό`�X�y�[�X���i�V���̂݁j
            tbj02vo.setSPACEFEE(null);
            //�X�v���b�g�������i�V���̂݁j
            tbj02vo.setSPLITRUNFEE(null);
            //�˗���i�V���̂݁j
            tbj02vo.setREQUESTDESTINATION(null);
            //������
            tbj02vo.setBRDDATE(null);
            //���l
            tbj02vo.setBIKO(null);
            //�����Ώۃt���O
            tbj02vo.setSEIKYUFLG("0");
            //���t�ݒ�(���W�I�^�C���̂�)
            tbj02vo.setCPDATE(getOnAirDay(vo, tbj02vo));
            //�b��(���W�I�^�C���̂�)
            tbj02vo.setBRDSEC(vo.getSECOND());
            //�󒍃t�@�C���o�̓t���O�i�V���̂݁j
            tbj02vo.setFILEOUTFLG("2");//���쐬

            /* 2015/11/24 JASRAC�Ή� HLC K.Soga MOD Start */
            //�f�ړ�
//            tbj02vo.setAPPEARANCEDATE(startDate);
            tbj02vo.setAPPEARANCEDATE(DateUtil.toDate(cond.getStartDate().replace("/", "")));

            //���ԊJ�n
            tbj02vo.setKIKANFROM(DateUtil.toDate(cond.getStartDate().replace("/", "")));

            //���ԏI��
            tbj02vo.setKIKANTO(DateUtil.toDate(cond.getEndDate().replace("/", "")));
            /* 2015/11/24 JASRAC�Ή� HLC K.Soga MOD End */

            //�\�[�g��
            tbj02vo.setSORTNO(tbj02MaxSortNo.add(BigDecimal.valueOf(i + 1)));
            i++;
            //�f�[�^�쐬��
            tbj02vo.setCRTNM(cond.getUpdNm());
            //�쐬�v���O����
            tbj02vo.setCRTAPL(cond.getUpdApl());
            //�쐬�S����ID
            tbj02vo.setCRTID(cond.getUpdId());
            //�f�[�^�X�V��
            tbj02vo.setUPDNM(cond.getUpdNm());
            //�X�V�v���O����
            tbj02vo.setUPDAPL(cond.getUpdApl());
            //�X�V�S����ID
            tbj02vo.setUPDID(cond.getUpdId());

            //�ǉ�
            tbj02VoList.add(tbj02vo);
        }

        return tbj02VoList;
    }

    /**
     * ��p���擾
     * @param vo �c�ƍ�Ƒ䒠���W�I�^�C���C���|�[�g��񌟍�VO
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    private List<Mbj09HiyouVO> getHiyouInfo(FindRdTime2AccountBookVO vo, FindRdTime2AccountBookCondition cond) throws HAMException {

        //��p�v��No�擾
        Mbj09HiyouDAO mbj09dao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition mbj09cond = new Mbj09HiyouCondition();
        mbj09cond.setDcarcd(vo.getDCARCD());
        mbj09cond.setMediacd(MEDIA_RADIOTIME);
        mbj09cond.setPhase(cond.getPhase());
        mbj09cond.setTerm(DateUtil.getTerm(cond.getYearMonth()));
        return mbj09dao.selectVO(mbj09cond);
    }

    /**
     * �������擾
     * @param vo �c�ƍ�Ƒ䒠�o�^�pVO
     * @param tbj02vo �c�ƍ�Ƒ䒠VO
     * @param dayCnt ����
     * @return ������(������)
     */
    private String getOnAirDay(FindRdTime2AccountBookVO vo, Tbj02EigyoDaichoVO tbj02vo) {

        //"MM/"�𐶐�
        StringBuilder sb = new StringBuilder();
        Integer month = Integer.parseInt(DateUtil.toString(tbj02vo.getKIKANFROM()).substring(4, 6));
        sb.append(month.toString() + "/");

        Calendar calendar = Calendar.getInstance();
        int weekday = 0;

        //���ԊJ�n���`���ԏI�����̓��t���X�g�쐬
        List<Integer> dayList = new ArrayList<Integer>();
        for (int i = 0; i <= DateUtil.getTermDays(tbj02vo.getKIKANFROM(), tbj02vo.getKIKANTO()); i++) {

            //���t�쐬
            calendar.setTime(tbj02vo.getKIKANFROM());
            calendar.add(Calendar.DATE, i);

            //�j�����擾(0=Sun..6=Sat)
            weekday = calendar.get(Calendar.DAY_OF_WEEK) - 1;

            //�j�����������̏ꍇ�A���X�g�ɒǉ�
            if (vo.getONAIRDAY().substring(weekday, weekday + 1).equals("1")) {
                dayList.add(calendar.get(Calendar.DATE));
            }
        }

        //�J�n���t
        Integer startDate = 0;
        //�I�����t
        Integer endDate = 0;

        //�擾�������t���X�g�����[�v����
        for (int i = 0; i < dayList.size(); i++) {

            //1����
            if (i == 0) {
                startDate = dayList.get(0);
                sb.append(startDate.toString());
                continue;
            }

            //�A��������t�̏ꍇ�A�I�����t�ɃZ�b�g
            if (dayList.get(i).equals(startDate + 1) || dayList.get(i).equals(endDate + 1)) {
                endDate = dayList.get(i);
                continue;
            } else {
                //�A��������t�̏ꍇ�A"-"�Ō���
                if (endDate != 0 && startDate != endDate) {
                    sb.append("-");
                    sb.append(endDate.toString());
                }

                //�A�����Ȃ����t��","�A����ъJ�n���t�Ō���
                sb.append(",");
                startDate = dayList.get(i);
                sb.append(startDate.toString());
                endDate = 0;
            }
        }

        //�I�����t�ƍŌ�̃f�[�^����v����ꍇ�A"-"�Ō���
        if (endDate.equals(dayList.get(dayList.size() - 1))) {
            sb.append("-");
            sb.append(dayList.get(dayList.size() - 1));
        }

        return sb.toString();
    }

}
