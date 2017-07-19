package jp.co.isid.ham.billing.model;

import jp.co.isid.ham.common.model.Tbj03MediaMngVO;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * �}�̔�Ǘ��o�^DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/4/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class RegisterMediaMngDAO extends AbstractRdbDao {

    Tbj03MediaMngVO _vo = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegisterMediaMngDAO() {
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
     * �f�t�H���g��SQL����Ԃ��܂�
     *
     * @return String SQL��
     */
    @Override
    public String getExecString() {

        StringBuffer sql = new StringBuffer();

        sql.append("INSERT INTO ");
        sql.append(Tbj03MediaMng.TBNAME);

        sql.append(" SELECT ");

        sql.append("NVL(MAX(");
        sql.append(Tbj03MediaMng.MEDIAMNGNO);
        sql.append("), 0) + 1");

        sql.append(",");
        sql.append(_vo.getPHASE());

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getMDYEAR());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getMDMONTH());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getDCARCD());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getMEDIACD());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getHMCOSTTOTAL());
        sql.append("'");

        sql.append(",");
        sql.append("SYSDATE");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getCRTNM());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getCRTAPL());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getCRTID());
        sql.append("'");

        sql.append(",");
        sql.append("SYSDATE");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getUPDNM());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getUPDAPL());
        sql.append("'");

        sql.append(",");
        sql.append("'");
        sql.append(_vo.getUPDID());
        sql.append("'");

        sql.append(" FROM ");
        sql.append(Tbj03MediaMng.TBNAME);


        return sql.toString();
    }

    /**
     * �}�̔�Ǘ���o�^����
     * @param vo �o�^�f�[�^
     * @throws HAMException
     */
    public void insertMediaMng(Tbj03MediaMngVO vo) throws HAMException {
        try {
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
