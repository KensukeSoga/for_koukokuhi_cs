package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMea12DisplayGyomKbn;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * ��ʁ|�Ɩ��敪DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class RepaVbjaMea12DisplayGyomKbnDAO extends AbstractSimpleRdbDao {

    /** �������� */
//    private RepaVbjaMea12DisplayGyomKbnCondition _condition = null;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMea12DisplayGyomKbnDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * �v���C�}���L�[���擾����
     *
     * @return String[] �v���C�}���L�[
     */
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * �X�V���t�t�B�[���h���擾����
     *
     * @return String �X�V���t�t�B�[���h
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * �V�X�e�����t�ōX�V���s���J�������̔z����擾����
     *
     * @return �V�X�e�����t�ōX�V���s���J�������̔z��
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return null;
    }

    /**
     * �e�[�u�������擾����
     *
     * @return String �e�[�u����
     */
    public String getTableName() {
        return RepaVbjaMea12DisplayGyomKbn.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                RepaVbjaMea12DisplayGyomKbn.JYUCTYPE
                ,RepaVbjaMea12DisplayGyomKbn.IRSKCD
                ,RepaVbjaMea12DisplayGyomKbn.IRSKSUBCD
                ,RepaVbjaMea12DisplayGyomKbn.GYOMKBNCD
                ,RepaVbjaMea12DisplayGyomKbn.GYOMKBNSHOWNO
                ,RepaVbjaMea12DisplayGyomKbn.KISEKBN
                ,RepaVbjaMea12DisplayGyomKbn.HKYMD
                ,RepaVbjaMea12DisplayGyomKbn.HAISYMD
                ,RepaVbjaMea12DisplayGyomKbn.INSDATE
                ,RepaVbjaMea12DisplayGyomKbn.INSTNTCD
                ,RepaVbjaMea12DisplayGyomKbn.INSAPLID
                ,RepaVbjaMea12DisplayGyomKbn.UPDAPLDATE
                ,RepaVbjaMea12DisplayGyomKbn.UPDTNTCD
                ,RepaVbjaMea12DisplayGyomKbn.UPDONLAPLID
                ,RepaVbjaMea12DisplayGyomKbn.UPDBATAPLID
        };
    }

}
