package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Vbj01AccUser;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �VHAM����VIEW(�l���)DAO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
public class Vbj01AccUserDAO extends AbstractSimpleRdbDao {

    /** �������� */
    private Vbj01AccUserCondition _condition = null;
    private List<Vbj01AccUserCondition> _conditionList = null;

    private enum SelSqlMode{DEF, ESQID5, MAIL, KK, }
    private SelSqlMode _selSqlMode = SelSqlMode.DEF;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Vbj01AccUserDAO() {
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
        return Vbj01AccUser.TBNAME;
    }

    /**
     * �e�[�u���񖼂��擾����
     *
     * @return String[] �e�[�u����
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Vbj01AccUser.ESQID
                ,Vbj01AccUser.POSTSTATE
                ,Vbj01AccUser.CN
                ,Vbj01AccUser.SIKOGNZUNTCD
                ,Vbj01AccUser.MAIL
                ,Vbj01AccUser.HBSIKOGNZUNTCD
                ,Vbj01AccUser.HBOU
                ,Vbj01AccUser.KKSIKOGNZUNTCD
                ,Vbj01AccUser.KKOU
                ,Vbj01AccUser.HTSIKOGNZUNTCD
                ,Vbj01AccUser.HTOU
                ,Vbj01AccUser.BUSIKOGNZUNTCD
                ,Vbj01AccUser.BUOU
                ,Vbj01AccUser.KASIKOGNZUNTCD
                ,Vbj01AccUser.KAOU
        };
    }

    /**
     * AbstractModel�̒l�̐ݒ�L������SQL��WHERE��𐶐�����
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo)
    {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sqlSelect = new StringBuffer();
        String whereSqlStr = "";

        if (_selSqlMode.equals(SelSqlMode.DEF)) {

            sqlSelect.append("SELECT ");
            //�S���ڂ��擾
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sqlSelect.append(getTableColumnNames()[i]);
                if (i < getTableColumnNames().length-1) {
                    sqlSelect.append(", ");
                }
            }
            sqlSelect.append(" FROM ");
            sqlSelect.append(getTableName());

            if (_condition != null) {
                Vbj01AccUserVO vo = new Vbj01AccUserVO();
                vo.setESQID(_condition.getEsqid());
                vo.setPOSTSTATE(_condition.getPoststate());
                vo.setCN(_condition.getCn());
                vo.setSIKOGNZUNTCD(_condition.getSikognzuntcd());
                vo.setMAIL(_condition.getMail());
                vo.setHBSIKOGNZUNTCD(_condition.getHbsikognzuntcd());
                vo.setHBOU(_condition.getHbou());
                vo.setKKSIKOGNZUNTCD(_condition.getKksikognzuntcd());
                vo.setKKOU(_condition.getKkou());
                vo.setHTSIKOGNZUNTCD(_condition.getHtsikognzuntcd());
                vo.setHTOU(_condition.getHtou());
                vo.setBUSIKOGNZUNTCD(_condition.getBusikognzuntcd());
                vo.setBUOU(_condition.getBuou());
                vo.setKASIKOGNZUNTCD(_condition.getKasikognzuntcd());
                vo.setKAOU(_condition.getKaou());
                whereSqlStr = generateWhereByCond(vo);
            }

        } else if (_selSqlMode.equals(SelSqlMode.ESQID5)) {

            sqlSelect.append("SELECT ");
            //�S���ڂ��擾
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sqlSelect.append(getTableColumnNames()[i]);
                if (i < getTableColumnNames().length-1) {
                    sqlSelect.append(", ");
                }
            }
            sqlSelect.append(" FROM ");
            sqlSelect.append(getTableName());
            sqlSelect.append(" WHERE ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " LIKE '_" + _condition.getEsqid() + "' ");

        } else if (_selSqlMode.equals(SelSqlMode.MAIL)) {

            sqlSelect.append("SELECT ");
            sqlSelect.append("  ").append(Vbj01AccUser.ESQID);
            sqlSelect.append(" ,").append(Vbj01AccUser.CN);
            sqlSelect.append(" ,").append(Vbj01AccUser.MAIL);
            sqlSelect.append(" FROM ");
            sqlSelect.append(getTableName());
            sqlSelect.append(" WHERE ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " IN (");
            for (int i = 0; i < _conditionList.size(); i++) {
                if (i > 0) {
                    sqlSelect.append(", ");
                }
                sqlSelect.append(getDBModelInterface().ConvertToDBString(_conditionList.get(i).getEsqid()));
            }
            sqlSelect.append(" ) ");
            sqlSelect.append(" GROUP BY ");
            sqlSelect.append("  ").append(Vbj01AccUser.ESQID);
            sqlSelect.append(" ,").append(Vbj01AccUser.CN);
            sqlSelect.append(" ,").append(Vbj01AccUser.MAIL);

        } else if (_selSqlMode.equals(SelSqlMode.KK)) {

            sqlSelect.append("SELECT ");

            sqlSelect.append(" " + Vbj01AccUser.ESQID + " ");
            sqlSelect.append("," + Vbj01AccUser.CN + " ");
            sqlSelect.append("," + Vbj01AccUser.MAIL + " ");
            sqlSelect.append("," + Vbj01AccUser.KKSIKOGNZUNTCD + " ");
            sqlSelect.append("," + Vbj01AccUser.KKOU + " ");

            sqlSelect.append(" FROM ");
            sqlSelect.append(getTableName());
            sqlSelect.append(" WHERE ");
            for (int i = 0; i < _conditionList.size(); i++) {
                if (i > 0) {
                    sqlSelect.append(" OR ");
                }
                sqlSelect.append(" ( ");
                sqlSelect.append(" " + Vbj01AccUser.ESQID + " = ");
                sqlSelect.append(getDBModelInterface().ConvertToDBString(_conditionList.get(i).getEsqid()));
                sqlSelect.append(" ) ");
            }
            sqlSelect.append(" GROUP BY ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " ");
            sqlSelect.append("," + Vbj01AccUser.CN + " ");
            sqlSelect.append("," + Vbj01AccUser.MAIL + " ");
            sqlSelect.append("," + Vbj01AccUser.KKSIKOGNZUNTCD + " ");
            sqlSelect.append("," + Vbj01AccUser.KKOU + " ");
            sqlSelect.append(" ORDER BY ");
            sqlSelect.append(" " + Vbj01AccUser.ESQID + " ");
        }

        return sqlSelect.toString() + whereSqlStr;
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectVO(Vbj01AccUserCondition condition) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _condition = condition;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ESQID(5��)�Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectByEsqId5(Vbj01AccUserCondition condition) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _condition = condition;
            _selSqlMode = SelSqlMode.ESQID5;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * �w�肵�������Ō������s���A�f�[�^���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectForEachKK(List<Vbj01AccUserCondition> condition) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _conditionList = condition;
            _selSqlMode = SelSqlMode.KK;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * ID��IN�������s���A���[���A�h���X���擾���܂�
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Vbj01AccUserVO> selectMail(List<Vbj01AccUserCondition> condition) throws HAMException {

        //�p�����[�^�`�F�b�N
        if (condition == null) {
            throw new HAMException("�����G���[", "BJ-E0001");
        }
        super.setModel(new Vbj01AccUserVO());

        try {
            _conditionList = condition;
            _selSqlMode = SelSqlMode.MAIL;
            return (List<Vbj01AccUserVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
