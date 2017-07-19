package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea11DisplayIrsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.Tbj35Knr;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * �˗���擾DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class FindContactRequestDAO extends AbstractSimpleRdbDao {

    FindContactRequestCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindContactRequestDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("   DECODE(" + RepaVbjaMea11DisplayIrsk.JYUCTYPE + ", '" + _condition.getJYUCTYPE() + "', " + RepaVbjaMea10Irsk.IRSKCD + " || " + RepaVbjaMea10Irsk.IRSKSUBCD + ", " + RepaVbjaMea10Irsk.IRSKCD + ") AS IRAISAKICODE,");
        sql.append("   DECODE(" + RepaVbjaMea10Irsk.ALASUSEFLG + ", '" + _condition.getALASUSEFLG() + "', " + RepaVbjaMea10Irsk.IRSKALASHYOJIKJ + ", " + RepaVbjaMeu07SikKrSprd.HYOJIKJ + ") AS IRAISAKINAME,");
        sql.append(    RepaVbjaMea11DisplayIrsk.DSIKKBNCD              + " AS DSIKKBNCD" + ", " );;
        sql.append(    RepaVbjaMea11DisplayIrsk.IRSKSHOWNO             + " AS IRSKSHOWNO  " );
        sql.append(" FROM ");
        sql.append(    RepaVbjaMea10Irsk.TBNAME + ", ");
        sql.append(    RepaVbjaMea11DisplayIrsk.TBNAME  + ", ");
        sql.append(    RepaVbjaMeu07SikKrSprd.TBNAME + ", ");
        sql.append(    Tbj35Knr.TBNAME);
        sql.append(" WHERE ");
        sql.append("     " + RepaVbjaMea11DisplayIrsk.ATSEGSYOCD  + " = '" + _condition.getATSEGSYOCD() + "'");
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.JYUCTYPE    + " = '" + _condition.getJYUCTYPE() + "'" );
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKCD      + " = "  + RepaVbjaMea10Irsk.IRSKCD);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKSUBCD   + " = "  + RepaVbjaMea10Irsk.IRSKSUBCD);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKCD      + " = "  + RepaVbjaMeu07SikKrSprd.SIKCD);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.JYUCFLG     + " = "  + "'" + _condition.getJYUCFLG() + "'" );
        sql.append(" AND " + RepaVbjaMea10Irsk.HKYMD              + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMea10Irsk.HAISYMD            + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.HKYMD       + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.HAISYMD     + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMeu07SikKrSprd.SIKCDKYK      + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMeu07SikKrSprd.ENDYMD        + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + Tbj35Knr.SYSTEMNO + " = '02'");

        sql.append(" GROUP BY " );
        sql.append(RepaVbjaMea11DisplayIrsk.JYUCTYPE + ", ");
        sql.append(RepaVbjaMea10Irsk.IRSKCD + ", ");
        sql.append(RepaVbjaMea10Irsk.IRSKSUBCD + ", ");
        sql.append(RepaVbjaMea10Irsk.ALASUSEFLG + ", ");
        sql.append(RepaVbjaMea10Irsk.IRSKALASHYOJIKJ + ", ");
        sql.append(RepaVbjaMeu07SikKrSprd.HYOJIKJ + ", ");
        sql.append(RepaVbjaMea11DisplayIrsk.DSIKKBNCD + ", ");
        sql.append(RepaVbjaMea11DisplayIrsk.IRSKSHOWNO);

        sql.append(" ORDER BY ");
        sql.append(" SUBSTR(" + RepaVbjaMea11DisplayIrsk.DSIKKBNCD + ", 1, 2), ");
        sql.append(  RepaVbjaMea11DisplayIrsk.IRSKSHOWNO + ", ");
        sql.append(  RepaVbjaMea10Irsk.IRSKCD + ", ");
        sql.append(  RepaVbjaMea10Irsk.IRSKSUBCD);

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion ��������
     * @return �擾�f�[�^
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindContactRequestVO> selectVO(FindContactRequestCondition condition) throws HAMException
    {
        // �p�����[�^�`�F�b�N
        if (condition == null)
        {
            throw new HAMException("�����G���[", "BJ-E0001");
        }

        super.setModel(new FindContactRequestVO());
        _condition = condition;

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }

    }

}
