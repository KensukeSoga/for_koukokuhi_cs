package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;
import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj10MediaSec;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
*
* <P>
* �c�ƍ�Ƒ䒠�̏��擾DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2013/01/18 HLC M.Tsuchiya)<BR>
* </P>
*
* @author HLC M.Tsuchiya
*/

public class FindMediaPlanDAO extends AbstractRdbDao {

    /** �f�[�^�������� */
    private FindMediaPlanCondition _cond;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMediaPlanDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return Tbj01MediaPlan.TBNAME;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj01MediaPlan.DCARCD,
                Tbj01MediaPlan.CAMPCD,
                Tbj01MediaPlan.MEDIAPLANNO,
                Tbj01MediaPlan.MEDIACD,
                Tbj01MediaPlan.HIYOUNO,
                Tbj01MediaPlan.PHASE,
                Tbj01MediaPlan.TERM,
                Tbj01MediaPlan.YOTEIYM,
                Tbj01MediaPlan.KIKANFROM,
                Tbj01MediaPlan.KIKANTO,
                Tbj01MediaPlan.BUDGET,
                Tbj01MediaPlan.BUDGETHM,
                Tbj01MediaPlan.ADJUSTMENT,
                Tbj01MediaPlan.ACTUAL,
                Tbj01MediaPlan.ACTUALHM,
                Tbj01MediaPlan.DIFAMT,
                Tbj01MediaPlan.DIFAMTHM,
                Tbj01MediaPlan.HMOK,
                Tbj01MediaPlan.BUYEROK,
                Tbj01MediaPlan.KENMEI,
                Tbj01MediaPlan.MEMO,
                Tbj01MediaPlan.CRTDATE,
                Tbj01MediaPlan.CRTNM,
                Tbj01MediaPlan.CRTAPL,
                Tbj01MediaPlan.CRTID,
                Tbj01MediaPlan.UPDDATE,
                Tbj01MediaPlan.UPDNM,
                Tbj01MediaPlan.UPDID,
                Tbj01MediaPlan.UPDAPL,
                Tbj01MediaPlan.BUDGETUPDFLG,
                Mbj03Media.MEDIANM,
                Mbj03Media.SORTNO,
                Mbj10MediaSec.AUTHORITY,
                Mbj05Car.KEIRETSUCD
        };
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getMediaPlan();
    }

    /**
     * �}�̏󋵊Ǘ���SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    private String getMediaPlan() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        //�S���ڂ��擾
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(",0 AS STATUS");
        sql.append(", " + Tbj01MediaPlan.CAMPCD + " || ' ' || "  + Tbj01MediaPlan.KENMEI + " AS CODENAME ");
        //0�Œ�ŕԂ�
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + ", ");
        sql.append(" Mbj03Media, ");
        sql.append(" Mbj05Car, ");
        sql.append(" Mbj10MediaSec, ");
        sql.append(" Mbj11CarSec ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " = " + Mbj03Media.MEDIACD +" ");
        sql.append(" AND ");
        sql.append(" " + Tbj01MediaPlan.DCARCD + " = " + Mbj05Car.DCARCD +" ");
        sql.append(" AND ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + " = " + Mbj10MediaSec.MEDIACD +" ");
        sql.append(" AND ");
        sql.append(" " + Tbj01MediaPlan.DCARCD + " = " + Mbj11CarSec.DCARCD +" ");
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.HAMID + " = " + Mbj11CarSec.HAMID +" ");
        sql.append(" AND ");
        sql.append(" " +   Mbj10MediaSec.HAMID + " = '" + _cond.getHamid() +"' ");
        sql.append(" AND ");
        sql.append(" " + Tbj01MediaPlan.PHASE + " = '" + _cond.getPhase() +"' ");
        sql.append(" AND ");
        sql.append(" " +  Tbj01MediaPlan.DCARCD + " = '" + _cond.getDcarcd() +"' ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.SECTYPE + " = '0' ");
        sql.append(" AND ");
        sql.append(" " + Mbj10MediaSec.AUTHORITY + " > 0 ");
        sql.append(" AND ");
        sql.append(" " + Mbj11CarSec.AUTHORITY + " > 0 ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj01MediaPlan.YOTEIYM + ", ");
        sql.append(" " + Mbj03Media.SORTNO + ", ");
        sql.append(" " + Tbj01MediaPlan.MEDIACD + ", ");
        sql.append(" " + Tbj01MediaPlan.MEDIAPLANNO + " ");

        return sql.toString();
    }

    /**
     * �}�̏󋵊Ǘ��̌������s���܂�
     *
     * @return �}�̏󋵊Ǘ�VO���X�g
     * @throws UserException
     *             �f�[�^�A�N�Z�X���ɃG���[�����������ꍇ
     */
    @SuppressWarnings("unchecked")
    public List<FindMediaPlanVO> findMediaPlanByCond(FindMediaPlanCondition cond) throws HAMException {

        super.setModel(new FindMediaPlanVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * Model�̐������s��<br>
     * �������ʂ�VO��KEY���啶���̂��ߕϊ��������s��<br>
     * AbstractRdbDao��createFindedModelInstances���I�[�o�[���C�h<br>
     *
     * @param hashList
     *            List ��������
     * @return List<FindMediaPlanVO> �ϊ���̌�������
     */
    @Override
    protected List<FindMediaPlanVO> createFindedModelInstances(List hashList) {

        List<FindMediaPlanVO> list = new ArrayList<FindMediaPlanVO>();

        if (getModel() instanceof FindMediaPlanVO) {
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                FindMediaPlanVO vo = new FindMediaPlanVO();

                vo.setDCARCD(((String)result.get(Tbj01MediaPlan.DCARCD.toUpperCase())));
                vo.setCAMPCD(((String)result.get(Tbj01MediaPlan.CAMPCD.toUpperCase())));
                vo.setMEDIAPLANNO(((BigDecimal)result.get(Tbj01MediaPlan.MEDIAPLANNO.toUpperCase())));
                vo.setMEDIACD(((String)result.get(Tbj01MediaPlan.MEDIACD.toUpperCase())));
                vo.setHIYOUNO(((String)result.get(Tbj01MediaPlan.HIYOUNO.toUpperCase())));
                vo.setPHASE(((BigDecimal)result.get(Tbj01MediaPlan.PHASE.toUpperCase())));
                vo.setTERM(((String)result.get(Tbj01MediaPlan.TERM.toUpperCase())));
                vo.setYOTEIYM(((Date)result.get(Tbj01MediaPlan.YOTEIYM.toUpperCase())));
                vo.setKIKANFROM(((Date)result.get(Tbj01MediaPlan.KIKANFROM.toUpperCase())));
                vo.setKIKANTO(((Date)result.get(Tbj01MediaPlan.KIKANTO.toUpperCase())));
                vo.setBUDGET(((BigDecimal)result.get(Tbj01MediaPlan.BUDGET.toUpperCase())));
                vo.setBUDGETHM(((BigDecimal)result.get(Tbj01MediaPlan.BUDGETHM.toUpperCase())));
                vo.setBUDGETUPDFLG(((String)result.get(Tbj01MediaPlan.BUDGETUPDFLG.toUpperCase())));
                vo.setADJUSTMENT(((BigDecimal)result.get(Tbj01MediaPlan.ADJUSTMENT.toUpperCase())));
                vo.setACTUAL(((BigDecimal)result.get(Tbj01MediaPlan.ACTUAL.toUpperCase())));
                vo.setACTUALHM(((BigDecimal)result.get(Tbj01MediaPlan.ACTUALHM.toUpperCase())));
                vo.setDIFAMT(((BigDecimal)result.get(Tbj01MediaPlan.DIFAMT.toUpperCase())));
                vo.setDIFAMTHM(((BigDecimal)result.get(Tbj01MediaPlan.DIFAMTHM.toUpperCase())));
                vo.setHMOK(((String)result.get(Tbj01MediaPlan.HMOK.toUpperCase())));
                vo.setBUYEROK(((String)result.get(Tbj01MediaPlan.BUYEROK.toUpperCase())));
                vo.setKENMEI(((String)result.get(Tbj01MediaPlan.KENMEI.toUpperCase())));
                vo.setMEMO(((String)result.get(Tbj01MediaPlan.MEMO.toUpperCase())));
                vo.setCRTDATE(((Date)result.get(Tbj01MediaPlan.CRTDATE.toUpperCase())));
                vo.setCRTNM(((String)result.get(Tbj01MediaPlan.CRTNM.toUpperCase())));
                vo.setCRTAPL(((String)result.get(Tbj01MediaPlan.CRTAPL.toUpperCase())));
                vo.setCRTID(((String)result.get(Tbj01MediaPlan.CRTID.toUpperCase())));
                vo.setUPDDATE(((Date)result.get(Tbj01MediaPlan.UPDDATE.toUpperCase())));
                vo.setUPDNM(((String)result.get(Tbj01MediaPlan.UPDNM.toUpperCase())));
                vo.setUPDAPL(((String)result.get(Tbj01MediaPlan.UPDAPL.toUpperCase())));
                vo.setUPDID(((String)result.get(Tbj01MediaPlan.UPDID.toUpperCase())));
                vo.setMEDIANM(((String)result.get(Mbj03Media.MEDIANM.toUpperCase())));
                vo.setSORTNO(((BigDecimal)result.get(Mbj03Media.SORTNO.toUpperCase())));
                vo.setAUTHORITY(((String)result.get(Mbj10MediaSec.AUTHORITY.toUpperCase())));
                vo.setKEIRETSUCD(((String)result.get(Mbj05Car.KEIRETSUCD.toUpperCase())));
                vo.setSTATUS((BigDecimal)result.get("STATUS"));
                vo.setCODENAME((String)result.get("CODENAME"));

                // �������ʒ���̏�Ԃɂ���
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}