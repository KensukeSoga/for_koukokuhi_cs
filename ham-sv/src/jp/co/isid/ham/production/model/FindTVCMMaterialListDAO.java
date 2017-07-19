package jp.co.isid.ham.production.model;

import java.util.List;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj42SozaiKanriListCmn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
* <P>
* TVCM�f�ވꗗ��񌟍�DAO
* </P>
* <P>
* <B>�C������</B><BR>
* �EHDX�Ή�(2016/03/07 HLC K.Oki)<BR>
* </P>
* @author K.Oki
*/
public class FindTVCMMaterialListDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private FindTVCMMaterialListCondition _cond = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindTVCMMaterialListDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[��Ԃ��܂�
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂�Ԃ��܂�
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{ };
    }

    /**
     * �e�[�u������Ԃ��܂�
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h��Ԃ��܂�
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getSelectSQL() {

        return getMaterialList();
    }

    /**
     * TVCM�f�ވꗗ��񌟍�SQL����Ԃ��܂�
     * @return String SQL��
     */
    private String getMaterialList() {

        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.HMSYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.HCSYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATETO_ATTR + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATETO + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATETO_ATTR + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TIMEUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTCTRT + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Mbj05Car.CARNM);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME  + " ON");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + Tbj20SozaiKanriList.CMCD);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + " ON");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " = " + Tbj20SozaiKanriList.TEMPCMCD);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME + " ON");
        sql.append(" " + Tbj42SozaiKanriListCmn.DCARCD + " = " + Tbj20SozaiKanriList.DCARCD +" AND");
        sql.append(" " + Tbj42SozaiKanriListCmn.SOZAIYM + " = " + Tbj20SozaiKanriList.SOZAIYM +" AND");
        sql.append(" " + Tbj42SozaiKanriListCmn.RECKBN + " = " + Tbj20SozaiKanriList.RECKBN +" AND");
        sql.append(" " + Tbj42SozaiKanriListCmn.RECNO + " = " + Tbj20SozaiKanriList.RECNO);
        sql.append(" LEFT OUTER JOIN");
        sql.append(" " + Mbj05Car.TBNAME + " ON");
        sql.append(" " + Mbj05Car.DCARCD + " = " + Tbj20SozaiKanriList.DCARCD);

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' '" + " AND");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + " = '" + HAMConstants.ONE + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_DATE('" + _cond.getYearMonth() +"', 'YYYYMM')");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD  + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD);

        return sql.toString();
    }

    /**
     * TVCM�f�ވꗗ��񌟍�
     * @param cond ��������
     * @return ��������
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindTVCMMaterialListVO> findTVCMMaterialList(FindTVCMMaterialListCondition cond) throws HAMException {

        // �p�����[�^�`�F�b�N
        if (cond == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new FindTVCMMaterialListVO());

        try {
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
